using MediatR;

namespace Tenants.Application.Commands
{
    public record LinkExternalAccountCommand(string Provider, string ExternalUserId, string UserId) : IRequest<bool>;
}