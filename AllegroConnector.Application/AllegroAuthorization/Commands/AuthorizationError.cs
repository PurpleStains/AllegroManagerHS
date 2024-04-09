using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class AuthorizationError : Error
    {
        public AuthorizationError(string message) : base(message) { }
    }
}
