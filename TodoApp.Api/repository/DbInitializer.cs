namespace Repository;

public static class DbInitializer
{
  public static void Seed(TodoDbContext context)
  {
    var todos = new List<Todo>
    {
      new Todo
      {
        Id = Guid.NewGuid(),
Name = "Todo1", Description = "Todo1 Description"
      },
new Todo
{
  Id = Guid.NewGuid(),
Name = "Todo2", Description  = "Todo2 Description"
}
    };

    if (!context.Todos.Any())
    {
      context.Todos.AddRange(todos);
      context.SaveChanges();
    }
  }

  public static void StartSeed(this WebApplication app)
  {
    using (var scope = app.Services.CreateScope())
    {
      var context = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
      DbInitializer.Seed(context);
    }
  }
}