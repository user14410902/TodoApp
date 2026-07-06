using FastEndpoints.AspVersioning;

namespace TodoApp.Endpoints.v1.Diagnostics;


public class TestGlobalExceptionHandler_V1 : EndpointWithoutRequest
{

  public TestGlobalExceptionHandler_V1()
  {
  }

  public override void Configure()
  {
    Get("/api/diagnostics/exception");
    AllowAnonymous();
    Options(x => x.WithVersionSet(">>Diagnostics<<").MapToApiVersion(1.0));

  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    //throw new InvalidOperationException($"Sample Exception {DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}");
    throw new Exception($"Sample Exception {DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}");
  }
}