using Microsoft.AspNetCore.Mvc;

using Tenants.Application.DTOs;
using Tenants.Application.Interfaces;

namespace Tenants.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly ITenantUserService _tenantUserService;

        public TenantController(ITenantService tenantService, ITenantUserService tenantUserService)
        {
            _tenantService = tenantService;
            _tenantUserService = tenantUserService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTenant([FromBody] string name, Guid? parentTenantId = null)
        {
            var tenant = await _tenantService.CreateTenantAsync(name, parentTenantId);
            return Ok(tenant);
        }

        [HttpPost("{tenantId}/users")]
        public async Task<IActionResult> CreateTenantUser(Guid tenantId, [FromBody] TenantUserDto userDto)
        {
            var user = await _tenantUserService.CreateTenantUserAsync(userDto.Email, userDto.FullName, tenantId, userDto.Roles);
            return Ok(user);
        }
    }
}