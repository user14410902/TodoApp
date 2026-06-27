namespace Repository;

public class Todo
{
  public Guid Id { get; set; }
  public DateTime Created { get; set; }
  public DateTime Updated { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public bool Completed { get; set; }
  public DateTime DueBy { get; set; }
}