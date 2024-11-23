using MediatR;

using Tenants.Domain.Entities;

namespace Tenants.Application.Commands;

public record UpdateTenantCommand(Guid TenantId, string Name, string Description) : IRequest<Unit>;