using Tenants.Domain.Common;
using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class Tenant : BaseAuditableEntity, IEntity
{
    public Guid TenantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Tenant(string name, string description, Guid? createdBy) : base(createdBy)
    {
        TenantId = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public override Guid GetIdentifier() => TenantId;
}