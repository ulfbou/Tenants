namespace Tenants.Application.DTOs
{
    public class TenantUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
