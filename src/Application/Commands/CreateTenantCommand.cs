using MediatR;

namespace Tenants.Application.Commands
{
    public record CreateTenantCommand(string Name, Guid? ParentTenantId) : IRequest<Guid>;
}