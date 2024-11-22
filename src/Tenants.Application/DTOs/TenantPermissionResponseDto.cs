using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantPermissionResponseDto : TenantPermissionCreateDto, IResponseDto
{
    public Guid TenantPermissionId { get; set; }

    public TenantPermissionResponseDto(Guid tenantPermissionId, Guid tenantId, string name, string description, string category) : base(tenantId, name, description, category)
    {
        TenantPermissionId = tenantPermissionId;
    }
}