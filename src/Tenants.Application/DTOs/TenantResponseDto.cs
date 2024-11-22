using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantResponseDto : TenantCreateDto, IResponseDto
{
    public Guid TenantId { get; set; }

    public TenantResponseDto(Guid tenantId, string name, string description) : base(name, description)
    {
        TenantId = tenantId;
    }
}