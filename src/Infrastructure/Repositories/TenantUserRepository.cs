using Microsoft.EntityFrameworkCore;

using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Infrastructure.Data;

namespace Tenants.Infrastructure.Repositories
{
    public class TenantUserRepository : ITenantUserRepository
    {
        private readonly ApplicationDbContext _context;

        public TenantUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TenantUser> AddTenantUserAsync(TenantUser tenantUser, CancellationToken cancellationToken = default)
        {
            _context.TenantUsers.Add(tenantUser);
            await _context.SaveChangesAsync(cancellationToken);
            return tenantUser;
        }

        public async Task<ICollection<TenantUser>> GetUsersByTenantIdAsync(Guid tenantId, CancellationToken cancellationToken = default)
        {
            return await _context.TenantUsers
                .Where(u => u.TenantId == tenantId)
                .Include(u => u.Roles)
                .ToListAsync(cancellationToken);
        }
    }
}