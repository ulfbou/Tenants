using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Common;

public abstract class BaseTenantEntity(Guid tenantId, Guid? createdBy = null) : BaseTenantEntity<Guid>(tenantId, createdBy) { }
public abstract class BaseTenantEntity<TIdentity> : BaseAuditableEntity<TIdentity>, ITenantEntity<TIdentity> where TIdentity : IEquatable<TIdentity>
{
    public Guid TenantId { get; set; }

    protected BaseTenantEntity(Guid tenantId, Guid? createdBy = null) : base(createdBy)
    {
        TenantId = tenantId;
    }
}