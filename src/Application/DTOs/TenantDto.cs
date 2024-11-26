namespace Tenants.Application.DTOs
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentTenantId { get; set; }
    }
}
