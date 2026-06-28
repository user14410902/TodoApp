using Responses;
using Requests;
using Microsoft.EntityFrameworkCore;
using Repository;
using FastEndpoints.AspVersioning;

namespace Endpoints.v1;

public class CreateNewTodo_V1 : Endpoint<TodoRequest, TodoResponse>
{
  private readonly IDbContextFactory<TodoDbContext> _contextFactory;

  public CreateNewTodo_V1(IDbContextFactory<TodoDbContext> contextFactory)
  {
    _contextFactory = contextFactory;
  }
  public override void Configure()
  {
    Post("/api/todos/create");
    AllowAnonymous();
    //Version(1).StartingRelease(1);
    Options(x => x.WithVersionSet(">>Todos<<").MapToApiVersion(1.0));
  }

  public override async Task HandleAsync(TodoRequest req, CancellationToken ct)
  {
    using (var context = _contextFactory.CreateDbContext())
    {
      var newTodo = new Todo
      {
        Name = req.Name,
        Description = req.Description,
        Completed = req.Completed,
        Created = DateTime.UtcNow,
        DueBy = req.DueBy
      };
      context.Todos.Add(newTodo);
      await context.SaveChangesAsync(ct);

      await Send.OkAsync(new TodoResponse
      {
        Id = newTodo.Id,
        Name = req.Name
      });

    }
  }
}