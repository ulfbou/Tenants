using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Interfaces;
using Tenants.Infrastructure.Repositories.MongoDB;

namespace Tenants.Infrastructure.Repositories;

public class TenantRepository(IMongoDbContext mongoDbContext, string? databaseName = null) : MongoRepository<Tenant>(mongoDbContext, databaseName), ITenantRepository { }
