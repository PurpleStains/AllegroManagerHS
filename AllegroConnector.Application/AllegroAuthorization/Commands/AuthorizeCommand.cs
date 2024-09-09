using AllegroConnector.Application.Contracts;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class AuthorizeCommand : CommandBase<Result<SuccessfullyAuthorizedResponseMessage>>
    {
        public int interval { get; }
        public string deviceCode { get; }
        public AuthorizeCommand(int interval, string deviceCode)
        {
            this.interval = interval;
            this.deviceCode = deviceCode;
        }
    }
}
