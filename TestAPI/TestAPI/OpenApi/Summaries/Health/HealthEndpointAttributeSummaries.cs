using Domain.ViewModels;
using CCFClean.Swagger.Summaries;

namespace TestAPI.OpenApi.Summaries.Health;

public static class HealthEndpointAttributeSummaries
{
    private const string _tagName = "Health";

    public static RouteHandlerBuilder GetHealthEndpointSummary<T>(this RouteHandlerBuilder endpoint) =>
        endpoint.AddMetaData(
            tag: _tagName,
            summary: "Health check",
            description: "Returns the current status, version, and UTC timestamp of the API. No authentication required.",
            responseAttributes: new List<SwaggerResponseAttributeExt>()
            {
                new(StatusCodes.Status200OK, null, typeof(T)),
                new(StatusCodes.Status500InternalServerError, null, typeof(ApiFailureResponse))
            });
}
