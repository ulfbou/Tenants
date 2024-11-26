namespace Tenants.Domain.Entities
{
    public class TenantUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string FullName { get; set; }
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}