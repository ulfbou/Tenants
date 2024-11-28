using MediatR;
using Tenants.Application.DTOs;

namespace Tenants.Application.Commands
{
    public record RegisterExternalUserCommand(ExternalRegisterRequest Request) : IRequest<UserDto>;
}