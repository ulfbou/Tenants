using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class PermissionResponseDto : PermissionCreateDto, IResponseDto
{
    public Guid PermissionId { get; set; }

    public PermissionResponseDto(Guid permissionId, string name, string description, string category) : base(name, description, category)
    {
        PermissionId = permissionId;
    }
}