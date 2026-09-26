using MediatR;
using Shared.Wrapper;
using Domain.Configs.Version;
using Microsoft.Extensions.Options;
using Application.Features.Version.Dtos;

namespace Application.Features.Version.Queries.GetVersion;

internal class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, Result<VersionDto>>
{
    private readonly VersionConfig _versionConfig;

    public GetVersionQueryHandler(IOptions<VersionConfig> versionConfig)
    {
        _versionConfig = versionConfig.Value;
    }

    public Task<Result<VersionDto>> Handle(GetVersionQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_versionConfig.Version))
            return Task.FromResult(Result.Failure<VersionDto>(VersionError.NotFound));

        var dto = new VersionDto { Version = _versionConfig.Version };
        return Task.FromResult(Result.Success(dto));
    }
}
