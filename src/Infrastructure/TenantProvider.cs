namespace Tenants.Infrastructure.Tenants
{
    public class TenantProvider : ITenantProvider
    {
        public Guid? TenantId { get; set; }
    }
}