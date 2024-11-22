using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantPermissionCreateDto : PermissionCreateDto, ICreateDto
{
    public Guid TenantId { get; set; }

    public TenantPermissionCreateDto(Guid tenantId, string name, string description, string category) : base(name, description, category)
    {
        TenantId = tenantId;
    }
}