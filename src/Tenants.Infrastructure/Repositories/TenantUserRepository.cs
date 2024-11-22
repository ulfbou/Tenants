using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Interfaces;
using Tenants.Infrastructure.Repositories.MongoDB;

namespace Tenants.Infrastructure.Repositories;

public class TenantUserRepository(IMongoDbContext mongoDbContext, string? databaseName = null) : MongoRepository<TenantUser>(mongoDbContext, databaseName), ITenantUserRepository { }