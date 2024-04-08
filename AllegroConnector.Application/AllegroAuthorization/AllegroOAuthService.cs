using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.BuildingBlocks.Domain;
using Newtonsoft.Json;

namespace AllegroConnector.Application.AllegroOAuth
{
    public sealed class AllegroOAuthService(HttpClient _client) : IAllegroOAuthService
    {
        private static readonly string ClientId = "bf60febe89224da9b379670e3ace98f5";

        public async Task<Result<AuthDeviceOAuth, AuthErrorResponse>> GetCode()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "device");
            request.Content = new FormUrlEncodedContent([
                new("Content-Type", "application/x-www-form-urlencoded"),
                new("client_id", ClientId),
            ]);

            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthDeviceOAuth>(responseString);
            }

            return new AuthErrorResponse() { error = "Failed to get code."};
        }

        public async Task<Result<AuthResponse, AuthErrorResponse>> GetAccessToken(int interval, string deviceCode, CancellationToken token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");
            request.Content = new FormUrlEncodedContent([
                 new("grant_type", "urn:ietf:params:oauth:grant-type:device_code"),
                 new("device_code", deviceCode)
            ]);
            var response = await _client.SendAsync(request, token);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AuthResponse>(responseString);
            }

            return JsonConvert.DeserializeObject<AuthErrorResponse>(responseString);
        }
    }
}
