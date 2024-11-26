namespace Tenants.Presentation.Middleware
{
    public static class TenantIsolationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTenantIsolation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenantIsolationMiddleware>();
        }
    }
}
