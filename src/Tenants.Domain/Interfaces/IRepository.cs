using Tenants.Domain.Common;

namespace Tenants.Domain.Interfaces;

public interface IRepository<TEntity> : IRepository<TEntity, Guid>
    where TEntity : IEntity
{
}
public interface IRepository<TEntity, TIdentity>
    where TEntity : IEntity<TIdentity>
    where TIdentity : IEquatable<TIdentity>
{
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(TIdentity id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(string? search, PaginationParameters? pagination, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}