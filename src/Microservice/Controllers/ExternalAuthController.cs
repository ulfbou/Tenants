using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tenants.Application.Commands;
using Tenants.Application.DTOs;
using Tenants.Application.Queries;

namespace Tenants.Microservice.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class ExternalAuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExternalAuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("providers")]
        public async Task<IActionResult> GetProviders()
        {
            var providers = await _mediator.Send(new GetExternalProvidersQuery());
            return Ok(providers);
        }

        [HttpGet("external/login/{provider}")]
        public async Task<IActionResult> ExternalLogin(string provider)
        {
            var authUrl = await _mediator.Send(new ExternalLoginRequest(provider));
            return Redirect(authUrl);
        }

        [HttpGet("external/callback")]
        public async Task<IActionResult> ExternalCallback(string provider, string state, string code)
        {
            var token = await _mediator.Send(new ExternalLoginCallbackRequest(provider, state, code));
            return Ok(new { token });
        }

        [HttpPost("external/link")]
        [Authorize]
        public async Task<IActionResult> LinkAccount([FromBody] ExternalLinkAccountRequest request)
        {
            var userId = User.Identity.Name; // Assuming User.Identity.Name is the UserId
            var result = await _mediator.Send(new LinkExternalAccountCommand(request.Provider, request.ExternalUserId, userId!));
            return result ? Ok("Account linked successfully.") : BadRequest("Failed to link account.");
        }

        [HttpPost("external/register")]
        public async Task<IActionResult> RegisterExternalUser([FromBody] ExternalRegisterRequest request)
        {
            var user = await _mediator.Send(new RegisterExternalUserCommand(request));
            return Ok(user);
        }
    }
}