using MediatR;
using Tenants.Application.Commands;
using Tenants.Application.Queries;
using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Tenants.Application.Handlers
{
    public class TenantCommandHandler :
        IRequestHandler<CreateTenantCommand, Tenant>,
        IRequestHandler<UpdateTenantCommand>,
        IRequestHandler<DeleteTenantCommand>,
        IRequestHandler<GetTenantQuery, Tenant>
    {
        private readonly IRepository<Tenant> _repository;

        public TenantCommandHandler(IRepository<Tenant> repository)
        {
            _repository = repository;
        }

        public async Task<Tenant> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant(request.Name, request.Description, request.CreatedBy);
            await _repository.AddAsync(tenant);
            return tenant;
        }

        public async Task<Unit> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetByIdAsync(request.TenantId);
            tenant.Name = request.Name;
            tenant.Description = request.Description;
            await _repository.UpdateAsync(tenant);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetByIdAsync(request.TenantId);
            await _repository.DeleteAsync(tenant);
            return Unit.Value;
        }

        public async Task<Tenant> Handle(ReadTenantQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.TenantId);
        }
    }
}