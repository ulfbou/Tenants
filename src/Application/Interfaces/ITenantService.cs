using Tenants.Application.DTOs;

namespace Tenants.Application.Interfaces
{
    public interface ITenantService
    {
        Task<TenantDto> CreateTenantAsync(string name, Guid? parentTenantId = null, CancellationToken cancellationToken = default);
        Task<ICollection<TenantDto>> GetTenantHierarchyAsync(Guid tenantId, CancellationToken cancellationToken = default);
    }
}