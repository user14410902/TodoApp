using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Repository;
using Responses;

namespace Endpoints;


public class GetAllTodos : EndpointWithoutRequest<List<TodoResponse>>
{
  private readonly IDbContextFactory<TodoDbContext> _contextFactory;

  public GetAllTodos(IDbContextFactory<TodoDbContext> contextFactory)
  {
    _contextFactory = contextFactory;
  }

  public override void Configure()
  {
    Get("/api/v1/todos");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    using (var context = _contextFactory.CreateDbContext())
    {
      await Send.OkAsync(context.Todos.Select(t => new TodoResponse { Id = t.Id, Name = t.Name }).ToList());
    }
  }
}