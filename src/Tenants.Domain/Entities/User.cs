using Microsoft.AspNetCore.Identity;

using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class User : IdentityUser<Guid>, IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public Guid? UpdatedBy { get; set; }

    public User(string userName, string email, Guid? createdBy = null) : base(userName)
    {
        Email = email;
        CreatedAt = DateTime.Now;
        LastModifiedAt = DateTime.Now;
        IsDeleted = false;
        CreatedBy = createdBy ?? Guid.Empty;
        UpdatedBy = Guid.NewGuid();
    }

    public Guid GetIdentifier() => Id;
}