using MongoDB.Driver;

using Tenants.Domain.Entities;
using Tenants.Infrastructure.Data.MongoDB;
using Tenants.Infrastructure.Interfaces;

namespace Tenants.Infrastructure.Repositories.MongoDB;

public class TenantRepository(IMongoDbContext mongoContext, string? databaseName = null) : MongoRepository<Tenant, Guid>(mongoContext, databaseName) { }