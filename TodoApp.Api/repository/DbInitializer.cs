namespace Repository;

public static class DbInitializer
{
  public static void Seed(TodoDbContext context)
  {
    var todos = new List<Todo>
    {
      new Todo
      {
        Id = 1,
Name = "Todo1"
      },
new Todo
{
  Id =2,
Name = "Todo2"
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