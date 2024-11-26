namespace Tenants.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid? ParentTenantId { get; set; }
        public Tenant ParentTenant { get; set; }
        public ICollection<Tenant> SubTenants { get; set; } = new List<Tenant>();
        public ICollection<TenantUser> Users { get; set; } = new List<TenantUser>();
    }
}