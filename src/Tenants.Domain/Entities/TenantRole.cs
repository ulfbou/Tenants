using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class TenantRole : Role, ITenantEntity
{
    public Guid TenantId { get; set; }

    public TenantRole(string name, string description, Guid tenantId, Guid? createdBy = null) : base(name, description, createdBy)
    {
        TenantId = tenantId;
    }
}