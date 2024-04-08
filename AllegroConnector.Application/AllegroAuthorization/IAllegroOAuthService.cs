using AllegroConnector.BuildingBlocks.Domain;

namespace AllegroConnector.Application.AllegroAuthorization
{
    public interface IAllegroOAuthService
    {
        Task<Result<AuthDeviceOAuth, AuthErrorResponse>> GetCode();
        Task<Result<AuthResponse, AuthErrorResponse>> GetAccessToken(int interval, string deviceCode, CancellationToken token);
    }
}
