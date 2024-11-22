namespace Tenants.Domain.Interfaces;

public interface ITenantEntity : ITenantEntity<Guid> { }
public interface ITenantEntity<TIdentity> where TIdentity : IEquatable<TIdentity>
{
    Guid TenantId { get; set; }
}