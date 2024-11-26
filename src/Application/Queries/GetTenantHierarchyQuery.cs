using MediatR;

using Tenants.Application.DTOs;

namespace Tenants.Application.Queries
{
    public record GetTenantHierarchyQuery(Guid TenantId) : IRequest<ICollection<TenantDto>>;
}