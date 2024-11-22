using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantRoleCreateDto : RoleCreateDto, ICreateDto
{
    public Guid TenantId { get; set; }

    public TenantRoleCreateDto(Guid tenantId, string? name, string description) : base(name, description)
    {
        TenantId = tenantId;
    }
}