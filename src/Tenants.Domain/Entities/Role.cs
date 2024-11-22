using Microsoft.AspNetCore.Identity;

using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class Role : IdentityRole<Guid>, IAuditableEntity
{
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public Guid? UpdatedBy { get; set; }

    public Role(string name, string description, Guid? createdBy = null) : base(name)
    {
        Description = description;
        CreatedAt = DateTime.Now;
        LastModifiedAt = DateTime.Now;
        IsDeleted = false;
        CreatedBy = createdBy ?? Guid.Empty;
        UpdatedBy = Guid.NewGuid();
    }

    public Guid GetIdentifier() => Id;
}