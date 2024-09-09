using AllegroConnector.Application.Contracts;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class IsAuthorizedCommand : CommandBase<Result<IsAuthorizedResponse>>
    {
    }
}
