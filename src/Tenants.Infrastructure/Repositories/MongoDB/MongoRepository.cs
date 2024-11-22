using MongoDB.Driver;

using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Interfaces;

namespace Tenants.Infrastructure.Repositories.MongoDB;

public class MongoRepository<TEntity> : MongoRepository<TEntity, Guid>, IRepository<TEntity>
    where TEntity : class, IEntity
{
    public MongoRepository(IMongoDbContext context, string? databaseName = null) : base(context, databaseName)
    {
    }
}

public class MongoRepository<TEntity, TIdentity> : IRepository<TEntity, TIdentity>
    where TEntity : class, IEntity<TIdentity>
    where TIdentity : IEquatable<TIdentity>
{
    protected readonly IMongoCollection<TEntity> _collection;

    public MongoRepository(IMongoDbContext context, string? databaseName = null)
    {
        _collection = context.GetCollection<TEntity, TIdentity>(databaseName ?? typeof(TEntity).Name);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _collection.InsertManyAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetByIdAsync(TIdentity id, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(e => e.GetIdentifier().Equals(id)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(e => e.GetIdentifier().Equals(entity.GetIdentifier()), entity, cancellationToken: cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            await UpdateAsync(entity, cancellationToken);
        }
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _collection.DeleteOneAsync(e => e.GetIdentifier().Equals(entity.GetIdentifier()), cancellationToken);
    }
}