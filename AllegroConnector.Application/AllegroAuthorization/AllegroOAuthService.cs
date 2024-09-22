using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Domain.OAuthToken;
using FluentResults;
using Newtonsoft.Json;

namespace AllegroConnector.Application.AllegroOAuth
{
    public sealed class AllegroOAuthService(HttpClient _client, string clientId) : IAllegroOAuthService
    {
        public async Task<Result<AuthDeviceOAuth>> GetCode()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "device");
            request.Content = new FormUrlEncodedContent([
                new("Content-Type", "application/x-www-form-urlencoded"),
                new("client_id", clientId)
            ]);

            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return Result.Ok<AuthDeviceOAuth>(JsonConvert.DeserializeObject<AuthDeviceOAuth>(responseString));
            }

            return Result.Fail("Failed to get code.");
        }

        public async Task<Result<AuthResponse>> GetAccessToken(int interval, string deviceCode, CancellationToken token)
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
                return Result.Ok<AuthResponse>(JsonConvert.DeserializeObject<AuthResponse>(responseString));
            }

            var errorResponse = JsonConvert.DeserializeObject<AuthErrorResponse>(responseString);
            return Result.Fail(errorResponse.error_description);
        }

        public async Task<Result<AuthResponse>> RefreshToken(AllegroOAuthToken credential, CancellationToken token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");
            request.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", credential.RefreshToken)
            });

            var response = await _client.SendAsync(request, token);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Result.Ok<AuthResponse>(JsonConvert.DeserializeObject<AuthResponse>(responseString));
            }

            var errorResponse = JsonConvert.DeserializeObject<AuthErrorResponse>(responseString);
            return Result.Fail(errorResponse.error_description);
        }
    }
}
