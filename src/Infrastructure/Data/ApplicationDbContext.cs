using Microsoft.EntityFrameworkCore;

using Tenants.Domain.Entities;
using Tenants.Infrastructure.Data;
using Tenants.Infrastructure.Tenants;

namespace Tenants.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ITenantProvider? _tenantProvider;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantProvider? tenantProvider = null)
            : base(options)
        {
            _tenantProvider = tenantProvider!;
        }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<TenantUser> TenantUsers => Set<TenantUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_tenantProvider?.TenantId is not null)
            {
                modelBuilder.Entity<TenantUser>().HasQueryFilter(t => _tenantProvider.TenantId == null || t.TenantId == _tenantProvider.TenantId);
            }
        }
    }
}