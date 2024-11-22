using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Entities;

public class TenantUser : User, ITenantEntity
{
    public Guid TenantId { get; set; }

    public TenantUser(string userName, string email, Guid tenantId, Guid? createdBy = null) : base(userName, email, createdBy)
    {
        TenantId = tenantId;
    }
}