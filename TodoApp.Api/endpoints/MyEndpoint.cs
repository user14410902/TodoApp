using FastEndpoints;
using Responses;
using Requests;

namespace Endpoints;

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
  public override void Configure()
  {
    Post("/api/v1/todos/create");
    AllowAnonymous();
  }

  public override async Task HandleAsync(MyRequest req, CancellationToken ct)
  {
    await Send.OkAsync(new()
    {
      FullName = req.FirstName + " " + req.LastName,
      IsOver18 = req.Age > 18
    });
  }
}