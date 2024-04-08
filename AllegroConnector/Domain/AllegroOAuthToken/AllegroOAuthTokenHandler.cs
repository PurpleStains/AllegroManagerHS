using AllegroConnector.Domain.OAuthToken;

namespace AllegroConnector.Infrastructure.Domain.AllegroOAuthToken
{
    internal class AllegroOAuthTokenHandler : IAllegroOAuthTokenHandler
    {
        private readonly IOAuthTokenRepository _repository;
        private string token;

        public AllegroOAuthTokenHandler(IOAuthTokenRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetAccessToken()
        {
            if (token is null)
            {
                var result = await _repository.Get();
                token = result.AccessToken;
            }

            return token;
        }
    }
}
