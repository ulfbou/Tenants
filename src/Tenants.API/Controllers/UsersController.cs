using Microsoft.AspNetCore.Mvc;

using Tenants.Application.Interfaces;

namespace Tenants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("{userId}/roles")]
    public async Task<IActionResult> AssignRolesToUser(Guid userId, [FromBody] List<Guid> roleIds)
    {
        await _userService.AssignRolesToUserAsync(userId, roleIds);
        return NoContent();
    }

    [HttpDelete("{userId}/roles/{roleId}")]
    public async Task<IActionResult> RemoveRoleFromUser(Guid userId, Guid roleId)
    {
        await _userService.RemoveRoleFromUserAsync(userId, roleId);
        return NoContent();
    }
}