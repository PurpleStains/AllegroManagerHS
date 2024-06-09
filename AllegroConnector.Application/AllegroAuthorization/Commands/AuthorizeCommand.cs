using AllegroConnector.Application.Contracts;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class AuthorizeCommand : CommandBase<Result<SuccessfullyAuthorizedResponseMessage>>
    {
        public int Interval { get; }
        public string DeviceCode { get; }
        public AuthorizeCommand(int interval, string deviceCode)
        {
            Interval = interval;
            DeviceCode = deviceCode;
        }
    }
}
