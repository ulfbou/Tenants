using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Data;
using Tenants.Infrastructure.Repositories;
using Tenants.Infrastructure.Tenants;

namespace Tenants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IDbContextFactory<ApplicationDbContext>, ApplicationDbContextFactory>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ITenantProvider, TenantProvider>();

            return services;
        }
    }
}
