using System.ComponentModel.DataAnnotations.Schema;

using Tenants.Domain.Interfaces;

namespace Tenants.Domain.Common;

public abstract class BaseEntity : BaseEntity<Guid> { }
public abstract class BaseEntity<TIdentity> : BaseDomainEntity, IEntity<TIdentity> where TIdentity : IEquatable<TIdentity>
{
    public abstract TIdentity GetIdentifier();
}