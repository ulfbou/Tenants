using Tenants.Application.DTOs;
using Tenants.Application.Interfaces;
using Tenants.Domain.Entities;
using Tenants.Domain.Exceptions;
using Tenants.Domain.Interfaces;

namespace Tenants.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<TenantDto> CreateTenantAsync(string name, Guid? parentTenantId = null, CancellationToken cancellationToken = default)
        {
            var tenant = new Tenant
            {
                Name = name,
                ParentTenantId = parentTenantId
            };

            var createdTenant = await _tenantRepository.AddTenantAsync(tenant, cancellationToken);

            if (createdTenant is null) throw new InvalidOperationException($"Failed to create tenant {name}{parentTenantId?.ToString() ?? string.Empty}.");

            return new TenantDto
            {
                Id = createdTenant.Id,
                Name = createdTenant.Name,
                ParentTenantId = createdTenant.ParentTenantId
            };
        }

        public async Task<ICollection<TenantDto>> GetTenantHierarchyAsync(Guid tenantId, CancellationToken cancellationToken = default)
        {
            var tenant = await _tenantRepository.GetTenantByIdAsync(tenantId, cancellationToken);

            if (tenant == null) throw new EntityNotFoundException(tenantId, typeof(Tenant).Name);

            var result = new List<TenantDto>
            {
                new TenantDto { Id = tenant.Id, Name = tenant.Name, ParentTenantId = tenant.ParentTenantId }
            };

            foreach (var subTenant in tenant.SubTenants)
            {
                result.Add(new TenantDto { Id = subTenant.Id, Name = subTenant.Name, ParentTenantId = subTenant.ParentTenantId });
            }

            return result;
        }
    }
}