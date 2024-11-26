using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

using Tenants.Infrastructure.Tenants;

namespace Tenants.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationDbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var options = _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
            var tenantProvider = _serviceProvider.GetRequiredService<ITenantProvider>();
            return new ApplicationDbContext(options, tenantProvider);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }
    }
}