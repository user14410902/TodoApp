using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;
using Repository;
using Responses;

namespace Endpoints.v1;


public class GetAllTodos_V1 : EndpointWithoutRequest<List<TodoResponse>>
{
  private readonly IDbContextFactory<TodoDbContext> _contextFactory;

  public GetAllTodos_V1(IDbContextFactory<TodoDbContext> contextFactory)
  {
    _contextFactory = contextFactory;
  }

  public override void Configure()
  {
    Get("/api/todos");
    //AllowAnonymous();
    //Version(1).StartingRelease(1);
    Options(x => x.WithVersionSet(">>Todos<<").MapToApiVersion(1.0));

  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    using (var context = _contextFactory.CreateDbContext())
    {
      await Send.OkAsync(context.Todos.Select(t => new TodoResponse { Id = t.Id, Name = t.Name }).ToList());
    }
  }
}