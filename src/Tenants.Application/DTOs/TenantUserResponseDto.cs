using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantUserResponseDto : TenantUserCreateDto, IResponseDto
{
    public Guid UserId { get; set; }

    public TenantUserResponseDto(Guid userId, string? username, Guid tenantId) : base(username, tenantId)
    {
        UserId = userId;
    }
}