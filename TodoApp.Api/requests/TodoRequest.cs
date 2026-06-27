namespace Requests;

public class TodoRequest
{
  public required string Name { get; set; }
  public required string Description { get; set; }
  public bool Completed { get; set; }
  public required DateTime DueBy { get; set; }

}