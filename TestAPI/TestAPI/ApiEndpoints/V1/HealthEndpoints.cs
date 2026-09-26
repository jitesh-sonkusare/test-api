using Asp.Versioning;
using CCFClean.Minimal.Definition;
using TestAPI.OpenApi.Summaries.Health;

namespace TestAPI.ApiEndpoints.V1;

public class HealthEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(AppBuilderDefinition builderDefinition)
    {
        var mapToApiVersion = new ApiVersion(1);
        var endpoint = builderDefinition.RouteBuilder;

        endpoint.MapGet("health", () =>
            {
                var version = typeof(Program).Assembly
                    .GetName().Version?.ToString(3) ?? "1.0.0";

                var response = new HealthResponse(
                    Status: "ok",
                    Version: version,
                    Timestamp: DateTime.UtcNow);

                return Results.Ok(response);
            })
            .GetHealthEndpointSummary<HealthResponse>()
            .MapToApiVersion(mapToApiVersion)
            .AllowAnonymous();
    }

    public void DefineServices(WebApplicationBuilder builder) { }
}
