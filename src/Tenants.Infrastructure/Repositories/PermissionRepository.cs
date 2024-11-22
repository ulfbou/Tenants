using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Interfaces;
using Tenants.Infrastructure.Repositories.MongoDB;

namespace Tenants.Infrastructure.Repositories;

public class PermissionRepository(IMongoDbContext mongoDbContext, string? databaseName = null) : MongoRepository<Permission>(mongoDbContext, databaseName), IPermissionRepository { }
