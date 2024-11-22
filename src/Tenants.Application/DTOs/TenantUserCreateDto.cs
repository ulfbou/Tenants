using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantUserCreateDto : UserCreateDto, ICreateDto
{
    public Guid TenantId { get; set; }

    public TenantUserCreateDto(string? username, Guid tenantId) : base(username)
    {
        TenantId = tenantId;
    }
}