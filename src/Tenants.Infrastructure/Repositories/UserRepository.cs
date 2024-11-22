using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Interfaces;
using Tenants.Infrastructure.Repositories.MongoDB;

namespace Tenants.Infrastructure.Repositories;

public class UserRepository(IMongoDbContext mongoDbContext, string? databaseName = null) : MongoRepository<User>(mongoDbContext, databaseName), IUserRepository { }
