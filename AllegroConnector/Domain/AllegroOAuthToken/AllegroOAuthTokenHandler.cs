using AllegroConnector.Domain.OAuthToken;

namespace AllegroConnector.Infrastructure.Domain.AllegroOAuthToken
{
    public class AllegroOAuthTokenHandler : IAllegroOAuthTokenHandler
    {
        private readonly IOAuthTokenRepository _repository;

        public AllegroOAuthTokenHandler(IOAuthTokenRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetToken()
        {
            var token = await _repository.Get();
            return token.AccessToken;
        }
    }
}
