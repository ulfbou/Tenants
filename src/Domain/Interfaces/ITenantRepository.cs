using Tenants.Domain.Entities;

namespace Tenants.Domain.Interfaces
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetTenantByIdAsync(Guid tenantId, CancellationToken cancellationToken = default);
        Task<Tenant?> AddTenantAsync(Tenant tenant, CancellationToken cancellationToken = default);
    }
}
