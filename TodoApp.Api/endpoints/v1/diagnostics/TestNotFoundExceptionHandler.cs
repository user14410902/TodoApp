using FastEndpoints.AspVersioning;
using TodoApp.Exceptions;
namespace TodoApp.Endpoints.v1.Diagnostics;


public class TestNotFoundExceptionHandler_V1 : EndpointWithoutRequest
{

  public TestNotFoundExceptionHandler_V1()
  {
  }

  public override void Configure()
  {
    Get("/api/diagnostics/notfoundexception");
    AllowAnonymous();
    Options(x => x.WithVersionSet(">>Diagnostics<<").MapToApiVersion(1.0));

  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    throw new NotFoundException("SampleResourceName", "SampleKey");
  }
}