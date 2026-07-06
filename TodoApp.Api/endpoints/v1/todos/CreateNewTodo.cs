using Microsoft.EntityFrameworkCore;
using FastEndpoints.AspVersioning;
using TodoApp.Requests;
using TodoApp.Responses;
using TodoApp.Repository;

namespace TodoApp.Endpoints.v1.Todos;

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
    Description(b => b
    .WithDisplayName("CreateNewTodo_V1")
    .WithDescription("Create a new todo.")
        .Accepts<TodoRequest>("application/json+custom")
        .Produces<TodoResponse>(200, "application/json+custom")
        .ProducesProblemFE(400) //shortcut for .Produces<ErrorResponse>(400)
        .ProducesProblemFE<InternalErrorResponse>(500));
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

      await Send.OkAsync(new TodoResponse(newTodo.Id, req.Name));

    }
  }
}