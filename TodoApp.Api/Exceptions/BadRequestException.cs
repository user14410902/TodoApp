using System.Net;

namespace TodoApp.Exceptions;

public sealed class BadRequestException : AppException
{
  public BadRequestException(string message)
      : base(message, HttpStatusCode.BadRequest)
  {
  }
}