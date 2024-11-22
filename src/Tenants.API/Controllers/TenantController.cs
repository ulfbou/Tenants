using Microsoft.AspNetCore.Mvc;
using Tenants.Application.Interfaces;
using Tenants.Application.DTOs;
using Tenants.Domain.Entities;

namespace Tenants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantsController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTenant([FromBody] TenantDto tenantDto)
    {
        var tenant = await _tenantService.CreateTenantAsync(tenantDto);
        return CreatedAtAction(nameof(GetTenant), new { id = tenant.Id }, tenant);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTenant(Guid id)
    {
        var tenant = await _tenantService.GetTenantByIdAsync(id);
        if (tenant == null)
        {
            return NotFound();
        }
        return Ok(tenant);
    }
}
