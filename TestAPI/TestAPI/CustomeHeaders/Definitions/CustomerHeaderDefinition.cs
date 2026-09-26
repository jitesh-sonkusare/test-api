using CCFClean.Minimal.Definition;
using CCFClean.Minimal.CustomHeader;
using TestAPI.CustomHeader;

namespace TestAPI.CustomeHeaders.Definitions;

public class CustomerHeaderDefinition : IEndpointDefinition
{
    public void DefineEndpoints(AppBuilderDefinition app)
    {
    }

    public void DefineServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IGlobalHeaders, GlobalHeaders>();
    }
}