namespace TodoApp.Responses;

//TODO Replace with record (as a learning exercise)

public class TodoResponse
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
}