using Tenants.Domain.Entities;

namespace Tenants.Domain.Interfaces
{
    public interface ITenantUserRepository
    {
        Task<TenantUser> AddTenantUserAsync(TenantUser tenantUser, CancellationToken cancellationToken = default);
        Task<ICollection<TenantUser>> GetUsersByTenantIdAsync(Guid tenantId, CancellationToken cancellationToken = default);
    }
}
