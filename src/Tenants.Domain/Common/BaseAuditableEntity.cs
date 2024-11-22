using System.Security.Principal;

using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Common;

public abstract class BaseAuditableEntity(Guid? createdBy = null) : BaseAuditableEntity<Guid>(createdBy)
{ }

public abstract class BaseAuditableEntity<TIdentity> : BaseDomainEntity, IAuditableEntity where TIdentity : IEquatable<TIdentity>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }

    protected BaseAuditableEntity(Guid? createdBy = null) : base()
    {
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = DateTime.UtcNow;
        IsDeleted = false;
        CreatedBy = createdBy ?? Guid.Empty;
    }

    public abstract Guid GetIdentifier();
}