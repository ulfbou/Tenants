using MediatR;

using Tenants.Application.Commands;
using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;

namespace Tenants.Application.Commands
{
    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Guid>
    {
        private readonly ITenantRepository _tenantRepository;

        public CreateTenantCommandHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant
            {
                Name = request.Name,
                ParentTenantId = request.ParentTenantId
            };

            var createdTenant = await _tenantRepository.AddTenantAsync(tenant);
            return createdTenant?.Id ?? Guid.Empty;
        }
    }
}