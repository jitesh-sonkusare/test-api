using Shared.Wrapper;

namespace Application.Features.Version.Dtos;

public static class VersionError
{
    public static readonly Error NotFound = new(
        "Version.NotFound", "Version not found!");
}
