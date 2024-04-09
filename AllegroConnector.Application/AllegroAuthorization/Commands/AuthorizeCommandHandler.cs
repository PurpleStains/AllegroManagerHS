using AllegroConnector.Application.Commands;
using AllegroConnector.Domain.OAuthToken;
using AutoMapper;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    internal class AuthorizeCommandHandler(IOAuthTokenRepository repository, IAllegroOAuthService apiClient, IMapper mapper)
        : ICommandHandler<AuthorizeCommand, Result<SuccessfullyAuthorizedResponseMessage>>
    {
        public async Task<Result<SuccessfullyAuthorizedResponseMessage>> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(request.Interval * 1000, cancellationToken);
            var response = await apiClient.GetAccessToken(request.Interval, request.DeviceCode, cancellationToken);
            if(response.IsSuccess)
            {
                var token = mapper.Map<AllegroOAuthToken>(response.Value);
                token.DateTimeStamp = DateTime.Now;
                token.ExpiresIn = DateTime.Now.AddSeconds(response.Value.expires_in);
                await repository.AddAsync(token);
                await repository.Commit();
                return Result.Ok(
                    new SuccessfullyAuthorizedResponseMessage("Successfully gathered access token from Allegro Api"));
            }

            return Result.Fail(new AuthorizationError(response.Errors.First().Message));
        }
    }
}
