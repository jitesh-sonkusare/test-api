using MediatR;
using Asp.Versioning;
using Shared.Wrapper;
using Domain.Configs.Version;
using CCFClean.Minimal.Definition;
using Application.Features.Version.Dtos;
using Application.Features.Version.Queries.GetVersion;
using TestAPI.OpenApi.Summaries.Version;

namespace TestAPI.ApiEndpoints.V1;

public class VersionEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(AppBuilderDefinition builderDefinition)
    {
        var mapToApiVersion = new ApiVersion(1);
        var endpoint = builderDefinition.RouteBuilder;

        // Get: Version
        endpoint.MapGet("version", async (ISender sender) =>
            {
                var result = await sender.Send(new GetVersionQuery());

                return result.Match(
                    onSuccess: version => Results.Ok(version),
                    onFailure: error => Results.NotFound(error));
            })
            .GetVersionEndpointSummary<Result<VersionDto>>()
            .MapToApiVersion(mapToApiVersion);
    }

    // Register DI related to this class/functionality.
    public void DefineServices(WebApplicationBuilder builder)
    {
        builder.Services
            .AddOptions<VersionConfig>()
            .Bind(builder.Configuration.GetSection(VersionConfig.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}
