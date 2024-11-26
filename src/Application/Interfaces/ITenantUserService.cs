using Tenants.Application.DTOs;

namespace Tenants.Application.Interfaces
{
    public interface ITenantUserService
    {
        Task<TenantUserDto> CreateTenantUserAsync(string email, string fullName, Guid tenantId, ICollection<string> roles);
    }
}