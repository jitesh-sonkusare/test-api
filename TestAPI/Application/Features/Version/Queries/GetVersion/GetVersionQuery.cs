using MediatR;
using Shared.Wrapper;
using Application.Features.Version.Dtos;

namespace Application.Features.Version.Queries.GetVersion;

public record GetVersionQuery : IRequest<Result<VersionDto>>;
