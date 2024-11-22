using Microsoft.AspNetCore.Mvc;
using Tenants.Application.Interfaces;
using Tenants.Application.DTOs;
using Tenants.API.DTOs;

namespace Tenants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePermission([FromBody] PermissionCreateDto permissionDto, CancellationToken cancellationToken)
    {
        var permission = await _permissionService.CreatePermissionAsync(permissionDto, cancellationToken);
        return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permission);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermission(Guid id)
    {
        var permission = await _permissionService.GetPermissionByIdAsync(id);
        return Ok(permission);
    }

    [HttpGet]
    public async Task<IActionResult> GetPermissions()
    {
        var permissions = await _permissionService.GetAllPermissionsAsync();
        return Ok(permissions);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePermission(Guid id, [FromBody] PermissionCreateDto permissionDto)
    {
        var permission = await _permissionService.UpdatePermissionAsync(id, permissionDto);
        return Ok(permission);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePermission(Guid id)
    {
        await _permissionService.DeletePermissionAsync(id);
        return NoContent();
    }
}
