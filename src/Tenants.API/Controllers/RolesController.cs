using Microsoft.AspNetCore.Mvc;
using Tenants.Application.Interfaces;
using Tenants.Application.DTOs;

namespace Tenants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roleService.GetRoleByIdAsync(id, cancellationToken);
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleCreateDto roleDto)
    {
        var role = await _roleService.CreateRoleAsync(roleDto);
        return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, role);
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleCreateDto roleDto)
    {
        var role = await _roleService.UpdateRoleAsync(id, roleDto);
        return Ok(role);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        await _roleService.DeleteRoleAsync(id);
        return NoContent();
    }
}