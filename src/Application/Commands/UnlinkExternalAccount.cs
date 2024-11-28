using MediatR;

namespace Tenants.Application.Commands
{
    public record UnlinkExternalAccountCommand(string Provider, string UserId) : IRequest<bool>;
}