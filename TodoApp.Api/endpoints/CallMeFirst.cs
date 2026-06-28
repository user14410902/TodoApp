using FastEndpoints.AspVersioning;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using Repository;
using Responses;

namespace Endpoints.v1;


public class CallMeFirst_V1 : EndpointWithoutRequest
{

  public override void Configure()
  {
    Post("/api/callmefirst");
    AllowAnonymous();
    //Version(1).StartingRelease(1);
    Options(x => x.WithVersionSet(">>Todos<<").MapToApiVersion(1.0));

  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    if (CheckCredentials())
    {
      var jwtToken = JwtBearer.CreateToken(
          o =>
          {
            o.SigningKey = "The secret used to sign tokens. Which must be at least 256 bits. Even longer";
            o.ExpireAt = DateTime.UtcNow.AddDays(1);
            o.User.Roles.Add("Manager", "Auditor");
            o.User.Claims.Add(("UserName", "Username"));
            o.User["UserId"] = "001"; //indexer based claim setting
          });

      await Send.OkAsync(
          new
          {
            Username = "Username",
            Token = jwtToken
          });
    }
    else
      ThrowError("The supplied credentials are invalid!");
  }

  private bool CheckCredentials()
  {
    //TODO Implement CheckCredentials
    return true;
  }
}