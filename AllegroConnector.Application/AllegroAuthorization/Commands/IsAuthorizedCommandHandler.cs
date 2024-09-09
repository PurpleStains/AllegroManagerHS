using AllegroConnector.Application.Commands;
using AllegroConnector.Domain.OAuthToken;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    internal class IsAuthorizedCommandHandler(IOAuthTokenRepository repository)
        : ICommandHandler<IsAuthorizedCommand, Result<IsAuthorizedResponse>>
    {
        public async Task<Result<IsAuthorizedResponse>> Handle(
            IsAuthorizedCommand request, 
            CancellationToken cancellationToken)
        {
            var token = await repository.Get();
            var isAuthorized = token is not null;
            return  Result.Ok(new IsAuthorizedResponse(isAuthorized));
        }
    }
}
