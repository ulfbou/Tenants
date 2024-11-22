using Tenants.Domain.Common;
using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class Permission : BaseAuditableEntity, IEntity
{
    public Guid PermissionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }

    public Permission(string name, string description, string category, Guid? createdBy = null) : base(createdBy)
    {
        PermissionId = Guid.NewGuid();
        Name = name;
        Description = description;
        Category = category;
    }

    public override Guid GetIdentifier() => PermissionId;
}