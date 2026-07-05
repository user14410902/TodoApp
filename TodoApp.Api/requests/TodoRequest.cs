namespace TodoApp.Requests;

public record TodoRequest(string Name, string Description, bool Completed, DateTime DueBy);
