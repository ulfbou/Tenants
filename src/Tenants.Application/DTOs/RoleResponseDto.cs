using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class RoleResponseDto : RoleCreateDto, IResponseDto
{
    public Guid RoleId { get; set; }

    public RoleResponseDto(Guid roleId, string? name, string description) : base(name, description)
    {
        RoleId = roleId;
    }
}