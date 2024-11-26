using Microsoft.EntityFrameworkCore;

using Tenants.Infrastructure.Data;
using Tenants.Infrastructure.Tenants;

namespace Tenants.Presentation.Middleware
{
    public class TenantIsolationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TenantIsolationMiddleware> _logger;

        public TenantIsolationMiddleware(RequestDelegate next, ILogger<TenantIsolationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tenantProvider = context.RequestServices.GetRequiredService<ITenantProvider>();
            var tenantIdHeader = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();
            if (!string.IsNullOrEmpty(tenantIdHeader) && Guid.TryParse(tenantIdHeader, out var parsedTenantId))
            {
                tenantProvider.TenantId = parsedTenantId;
                _logger.LogInformation("Resolved TenantId: {TenantId}", parsedTenantId);
            }
            else
            {
                _logger.LogWarning("TenantId header is missing or invalid.");
            }

            await _next(context);
        }
    }
}