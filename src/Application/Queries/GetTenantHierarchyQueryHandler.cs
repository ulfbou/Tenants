using MediatR;

using Tenants.Application.DTOs;
using Tenants.Domain.Entities;
using Tenants.Domain.Exceptions;
using Tenants.Domain.Interfaces;

namespace Tenants.Application.Queries
{
    public class GetTenantHierarchyQueryHandler : IRequestHandler<GetTenantHierarchyQuery, ICollection<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;

        public GetTenantHierarchyQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<ICollection<TenantDto>> Handle(GetTenantHierarchyQuery request, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.GetTenantByIdAsync(request.TenantId);

            if (tenant is null) throw new EntityNotFoundException(request.TenantId, typeof(Tenant).Name);

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