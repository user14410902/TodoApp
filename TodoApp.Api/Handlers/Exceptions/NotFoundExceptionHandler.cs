using Microsoft.AspNetCore.Diagnostics;
using TodoApp.Exceptions;

namespace TodoApp.Handlers.Exceptions;

public sealed class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(
      HttpContext httpContext,
      Exception exception,
      CancellationToken cancellationToken)
  {
    if (exception is not NotFoundException notFound)
    {
      return false; // Let the next handler try
    }

    logger.LogWarning("Resource not found: {Message}", notFound.Message);

    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
    {
      Status = 404,
      //Title = "Resource Not Found",
      Detail = notFound.Message
    }, cancellationToken);

    return true; // We handled it
  }
}