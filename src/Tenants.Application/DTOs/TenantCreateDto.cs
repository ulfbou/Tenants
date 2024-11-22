using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class TenantCreateDto : ICreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? CreatedBy { get; set; }

    public TenantCreateDto(string name, string description)
    {
        Name = name;
        Description = description;
    }
}