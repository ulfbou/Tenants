using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tenants.Application.Commands;
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
        private readonly IMediator _mediator;
        private readonly ILogger<TenantController> _logger;

        public TenantController(ITenantService tenantService, ITenantUserService tenantUserService, IMediator mediator, ILogger<TenantController> logger)
        {
            _tenantService = tenantService;
            _tenantUserService = tenantUserService;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTenant([FromBody] CreateTenantCommand request)
        {
            // TODO: Additional validation
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Tenant name is required");
            }

            //var tenant = await _tenantService.CreateTenantAsync(name, parentTenantId);
            var tenant = await _mediator.Send(request);

            if (tenant == Guid.Empty)
            {
                _logger.LogWarning($"Failed to create tenant {request.Name}{request.ParentTenantId?.ToString() ?? string.Empty}.");
                return StatusCode(500);
            }

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