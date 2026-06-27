using Microsoft.EntityFrameworkCore;

namespace Repository;

public class TodoDbContext : DbContext
{
  public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
  {

  }

  public DbSet<Todo> Todos { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}