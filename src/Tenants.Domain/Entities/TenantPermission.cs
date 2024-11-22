using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class TenantPermission : Permission, ITenantEntity
{
    public Guid TenantId { get; set; }

    public TenantPermission(string name, string description, string category, Guid tenantId, Guid? createdBy = null) : base(name, description, category, createdBy)
    {
        TenantId = tenantId;
    }
}