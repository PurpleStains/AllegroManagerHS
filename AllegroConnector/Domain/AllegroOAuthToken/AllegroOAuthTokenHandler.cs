using AllegroConnector.Domain.OAuthToken;

namespace AllegroConnector.Infrastructure.Domain.AllegroOAuthToken
{
    internal class AllegroOAuthTokenHandler(IOAuthTokenRepository repository) : IAllegroOAuthTokenHandler
    {
        private string token;

        public string GetAccessToken()
        {
            if (token is null)
            {
                var result = repository.Get().Result;
                token = result.AccessToken;
            }

            return token;
        }
    }
}
