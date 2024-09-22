using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Domain.OAuthToken;
using AutoMapper;

namespace AllegroConnector.Infrastructure.Domain.AllegroOAuthToken
{
    public class AllegroOAuthTokenHandler(
        IOAuthTokenRepository repository,
        IAllegroOAuthService oAuthApi,
        IMapper mapper)
        : IAllegroOAuthTokenHandler
    {

        public async Task<string> GetToken()
        {
            var token = await repository.Get();
            if (token.ExpiresIn.AddMinutes(20) <= DateTime.Now)
            {
                var result = await oAuthApi.RefreshToken(token, CancellationToken.None);
                if (result.IsFailed) return "";

                var newToken = mapper.Map<AllegroConnector.Domain.OAuthToken.AllegroOAuthToken>(result.Value);
                newToken.DateTimeStamp = DateTime.Now;
                newToken.ExpiresIn = DateTime.Now.AddSeconds(result.Value.expires_in);
                await repository.AddAsync(newToken);
                await repository.Commit();
                return newToken.AccessToken;
            }

            return token.AccessToken;
        }
    }
}
