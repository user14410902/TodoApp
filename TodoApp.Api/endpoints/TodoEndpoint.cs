using FastEndpoints;
using Responses;

namespace Endpoints;

public class TodoEndpoint : EndpointWithoutRequest<List<TodoResponse>>
{
  public override void Configure()
  {
    Get("/api/v1/todos");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var todos = new List<TodoResponse>
    {
      new TodoResponse {
      Name = "Todo1"
      }, new TodoResponse
      {
        Name = "Todo2"
      }
    };
    await Send.OkAsync(todos);
  }
}