using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantRoleResponseDto : TenantRoleCreateDto, IResponseDto
{
    public Guid TenantRoleId { get; set; }
    public TenantRoleResponseDto(Guid tenantRoleId, Guid tenantId, string? name, string description) : base(tenantId, name, description)
    {
        TenantRoleId = tenantRoleId;
    }
}