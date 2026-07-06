using System.Net;
using FastEndpoints.AspVersioning;

namespace TodoApp.Endpoints.v1.Diagnostics;


public class BadRequest_V1 : EndpointWithoutRequest
{

  public BadRequest_V1()
  {
  }

  public override void Configure()
  {
    Get("/api/diagnostics/badrequest");
    AllowAnonymous();
    Options(x => x.WithVersionSet(">>Diagnostics<<").MapToApiVersion(1.0));

  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    await Send.ErrorsAsync((int)HttpStatusCode.BadRequest, ct);
  }
}