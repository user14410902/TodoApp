using FastEndpoints;
using Responses;
using Requests;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Endpoints;

public class CreateNewTodo : Endpoint<TodoRequest, TodoResponse>
{
  private readonly IDbContextFactory<TodoDbContext> _contextFactory;

  public CreateNewTodo(IDbContextFactory<TodoDbContext> contextFactory)
  {
    _contextFactory = contextFactory;
  }
  public override void Configure()
  {
    Post("/api/v1/todos/create");
    AllowAnonymous();
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