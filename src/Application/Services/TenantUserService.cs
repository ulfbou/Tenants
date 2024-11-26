using Tenants.Application.DTOs;
using Tenants.Application.Interfaces;
using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;

namespace Tenants.Application.Services
{
    public class TenantUserService : ITenantUserService
    {
        private readonly ITenantUserRepository _tenantUserRepository;

        public TenantUserService(ITenantUserRepository tenantUserRepository)
        {
            _tenantUserRepository = tenantUserRepository;
        }

        public async Task<TenantUserDto> CreateTenantUserAsync(string email, string fullName, Guid tenantId, ICollection<string> roles)
        {
            var tenantUser = new TenantUser
            {
                Email = email,
                FullName = fullName,
                TenantId = tenantId,
                Roles = roles.Select(r => new UserRole { RoleName = r }).ToList()
            };

            var createdUser = await _tenantUserRepository.AddTenantUserAsync(tenantUser);

            return new TenantUserDto
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FullName = createdUser.FullName,
                Roles = createdUser.Roles.Select(r => r.RoleName).ToList()
            };
        }
    }
}