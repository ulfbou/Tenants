using MongoDB.Driver;

using Tenants.Domain.Interfaces;

namespace Tenants.Infrastructure.Interfaces;

public interface IMongoDbContext
{
    IMongoCollection<TEntity> GetCollection<TEntity, TIdentity>(string name) where TEntity : IEntity<TIdentity> where TIdentity : IEquatable<TIdentity>;
}