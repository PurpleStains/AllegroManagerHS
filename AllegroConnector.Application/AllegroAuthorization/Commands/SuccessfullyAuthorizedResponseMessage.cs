using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class SuccessfullyAuthorizedResponseMessage : Success
    {
        public SuccessfullyAuthorizedResponseMessage(string message)
            : base(message) { }
    }
}
