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
            while (true)
            {
                int interval = request.Interval;
                await Task.Delay(interval * 1000, cancellationToken);
                var response = await apiClient.GetAccessToken(request.Interval, request.DeviceCode, cancellationToken);
                AllegroOAuthToken token = null;
                string errorMessage = string.Empty;
                response.Match(
                    resultValue =>
                    {
                        token = mapper.Map<AllegroOAuthToken>(resultValue);
                        token.DateTimeStamp = DateTime.Now;
                        token.ExpiresIn = DateTime.Now.AddSeconds(resultValue.expires_in);
                        return resultValue;
                    },
                    error =>
                    {
                        errorMessage = error.error_description;
                        return error;
                    });



                if (response.IsSuccess)
                {
                    await repository.AddAsync(token);
                    await repository.Commit();
                    return;
                }


                if (errorMessage == "authorization_pending")
                {
                    logger.Information("Authorization pending...");
                    continue;
                }
                else if (errorMessage == "slow_down")
                {
                    interval += interval;
                    continue;
                }
                else if (errorMessage == "access_denied")
                {
                    throw new Exception("Access denied.");
                }
                else if (errorMessage == "Invalid device code")
                {
                    throw new Exception("Invalid device code.");
                }
            }
        }
    }
}
