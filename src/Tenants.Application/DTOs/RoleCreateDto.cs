using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class RoleCreateDto : ICreateDto
{
    public string? Name { get; set; }
    public string Description { get; set; }

    public RoleCreateDto(string? name, string description)
    {
        Name = name;
        Description = description;
    }
}