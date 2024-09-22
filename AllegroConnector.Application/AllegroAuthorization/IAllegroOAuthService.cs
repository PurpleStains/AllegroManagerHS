using AllegroConnector.Domain.OAuthToken;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization
{
    public interface IAllegroOAuthService
    {
        Task<Result<AuthDeviceOAuth>> GetCode();
        Task<Result<AuthResponse>> GetAccessToken(int interval, string deviceCode, CancellationToken token);
        Task<Result<AuthResponse>> RefreshToken(AllegroOAuthToken credential, CancellationToken token);
    }
}
