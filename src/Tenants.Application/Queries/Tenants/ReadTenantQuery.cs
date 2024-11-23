using MediatR;

using Tenants.Domain.Entities;

namespace Tenants.Application.Queries;

public record ReadTenantQuery(Guid TenantId) : IRequest<Tenant>;