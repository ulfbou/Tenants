using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class PermissionCreateDto : ICreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }

    public PermissionCreateDto(string name, string description, string category)
    {
        Name = name;
        Description = description;
        Category = category;
    }
}