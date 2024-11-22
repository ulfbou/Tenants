namespace Tenants.API.DTOs
{
    public class CreateTenantDto
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
    }
}