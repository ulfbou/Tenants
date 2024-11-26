namespace Tenants.Infrastructure.Tenants
{
    public interface ITenantProvider
    {
        Guid? TenantId { get; set; }
    }
}