using Tenants.Domain.Entities;

namespace Tenants.Infrastructure.Authentication
{
    public interface IOAuthService
    {
        Task<string> GetAuthorizationUrlAsync(string provider);
        Task<ExternalProvider?> GetProviderMetadataAsync(string provider);
        Task<string> HandleCallbackAsync(string provider, string state, string code);
    }

    public class OAuthService : IOAuthService
    {
        private readonly IConfiguration _configuration;

        public OAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GetAuthorizationUrlAsync(string provider)
        {
            var baseUrl = _configuration[$"OAuthProviders:{provider}:AuthorizationUrl"];
            var clientId = _configuration[$"OAuthProviders:{provider}:ClientId"];
            var redirectUri = _configuration[$"OAuthProviders:{provider}:RedirectUri"];
            var state = Guid.NewGuid().ToString();

            return Task.FromResult($"{baseUrl}?client_id={clientId}&redirect_uri={redirectUri}&state={state}&response_type=code&scope=email profile");
        }

        public Task<ExternalProvider?> GetProviderMetadataAsync(string provider)
        {
            var metadata = _configuration.GetSection($"OAuthProviders:{provider}");
            if (metadata == null) return Task.FromResult<ExternalProvider?>(null);

            return Task.FromResult<ExternalProvider?>(new ExternalProvider(
                provider,
                metadata["LoginUrl"],
                metadata["IconUrl"]
            ));
        }

        public Task<string> HandleCallbackAsync(string provider, string state, string code)
        {
            // Mock implementation for simplicity
            return Task.FromResult("generated-token");
        }
    }
}