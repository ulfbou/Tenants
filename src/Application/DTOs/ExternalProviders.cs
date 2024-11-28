namespace Tenants.Application.DTOs
{
    public record ExternalProviderDto(string Name, string LoginUrl, string IconUrl);

    public record ExternalLoginRequest(string Provider);

    public record ExternalLoginCallbackRequest(string Provider, string State, string Code);

    public record ExternalLinkAccountRequest(string Provider, string ExternalUserId);

    public record ExternalRegisterRequest(string Provider, string ExternalUserId, string Email, string Username);
}