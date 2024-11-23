using MediatR;

namespace Tenants.Application.Commands;

public record DeleteTenantCommand(Guid TenantId) : IRequest<Unit>;