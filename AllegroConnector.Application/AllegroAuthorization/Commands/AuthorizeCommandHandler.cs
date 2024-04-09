using AllegroConnector.Application.Commands;
using AllegroConnector.Domain.OAuthToken;
using AutoMapper;
using Serilog;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    internal class AuthorizeCommandHandler(IOAuthTokenRepository repository, IAllegroOAuthService apiClient, IMapper mapper, ILogger logger)
        : ICommandHandler<AuthorizeCommand>
    {
        public async Task Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(request.Interval * 1000, cancellationToken);
            var response = await apiClient.GetAccessToken(request.Interval, request.DeviceCode, cancellationToken);
            AllegroOAuthToken token = null;
            var result = response.Match(
                resultValue =>
                {
                    token = mapper.Map<AllegroOAuthToken>(resultValue);
                    token.DateTimeStamp = DateTime.Now;
                    token.ExpiresIn = DateTime.Now.AddSeconds(resultValue.expires_in);
                    logger.Information("Successfully gathered access token from Allegro Api");
                    return resultValue;
                },
                error =>
                {
                    logger.Error(error.error_description);
                    return error;
                });

            if (result.IsSuccess)
            {
                await repository.AddAsync(token);
                await repository.Commit();
            }
        }
    }
}
