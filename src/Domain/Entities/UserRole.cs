namespace Tenants.Domain.Entities
{
    public class UserRole
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string RoleName { get; set; }
        public Guid TenantUserId { get; set; }
        public TenantUser TenantUser { get; set; }
    }
}