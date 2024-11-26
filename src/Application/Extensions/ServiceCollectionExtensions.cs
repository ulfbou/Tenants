using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Tenants.Application.Behavior;
using Tenants.Application.Commands;
using Tenants.Application.Interfaces;
using Tenants.Application.Services;

namespace Tenants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTenantCommandHandler).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<ITenantUserService, TenantUserService>();
            return services;
        }

        public static IServiceCollection AddLoggingBehavior(this IServiceCollection services)
        {
            // Register LoggingBehavior for all MediatR pipeline requests
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}