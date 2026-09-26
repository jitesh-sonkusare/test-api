using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CCFClean.Swagger.Summaries;

namespace TestAPI.OpenApi.Summaries.Version;

public static class VersionEndpointAttributeSummaries
{
    private const string _tagName = "Version";

    public static RouteHandlerBuilder GetVersionEndpointSummary<T>(this RouteHandlerBuilder endpoint) =>
        endpoint.AddMetaData(
            tag: _tagName,
            summary: "Get application version",
            description: "Use this api endpoint to get the current application version.",
            responseAttributes: new List<SwaggerResponseAttributeExt>()
            {
                new(StatusCodes.Status200OK, null, typeof(T)),
                new(StatusCodes.Status404NotFound, null, typeof(T)),
                new(StatusCodes.Status400BadRequest, null, typeof(ApiFailureResponse)),
                new(StatusCodes.Status500InternalServerError, null, typeof(ApiFailureResponse))
            });
}
