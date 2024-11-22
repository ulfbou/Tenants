namespace Tenants.Domain.Interfaces;

public interface IEntity : IEntity<Guid> { }
public interface IEntity<TIdentity> where TIdentity : IEquatable<TIdentity>
{
    TIdentity GetIdentifier();
}