using MediatR;
using Tenants.Domain.Entities;

namespace Tenants.Application.Commands
{
    public record CreateTenantCommand(string Name, string Description, Guid CreatedBy) : IRequest<Tenant>;
}