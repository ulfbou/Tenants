using MediatR;
using Tenants.Application.DTOs;

namespace Tenants.Application.Queries
{
    public record GetExternalProvidersQuery : IRequest<List<ExternalProviderDto>>;
}