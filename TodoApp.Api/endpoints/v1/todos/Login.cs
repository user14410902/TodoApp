using FastEndpoints.AspVersioning;
using FastEndpoints.Security;
using TodoApp.Requests;
using TodoApp.Responses;

namespace TodoApp.Endpoints.v1.Todos;

public class Login_V1 : Endpoint<LoginRequest, LoginResponse>
{

  public override void Configure()
  {
    Post("/api/login");
    AllowAnonymous();
    Options(x => x.WithVersionSet(">>Todos<<").MapToApiVersion(1.0));

  }

  public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
  {
    if (CheckCredentials(req.username, req.password))
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

      await Send.OkAsync(new LoginResponse(jwtToken));
    }
    else
      ThrowError("The supplied credentials are invalid!");
  }

  private bool CheckCredentials(string username, string password)
  {
    //TODO Implement CheckCredentials
    return true;
  }
}