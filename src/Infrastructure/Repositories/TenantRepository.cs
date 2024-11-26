using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Data;

namespace Tenants.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TenantRepository> _logger;

        public TenantRepository(ApplicationDbContext context, ILogger<TenantRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Tenant?> GetTenantByIdAsync(Guid tenantId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.Tenants
                            .Include(t => t.SubTenants)
                            .FirstOrDefaultAsync(t => t.Id == tenantId, cancellationToken);
            }
            catch (Exception ex)
            {
                using var scope = _logger.BeginScope("GetTenantByIdAsync: {0}", tenantId);
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<Tenant?> AddTenantAsync(Tenant tenant, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Tenants.AddAsync(tenant);
                await _context.SaveChangesAsync(cancellationToken);
                return tenant;
            }
            catch (Exception ex)
            {
                using var scope = _logger.BeginScope("AddTenantAsync: {0}", tenant.Name);
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}