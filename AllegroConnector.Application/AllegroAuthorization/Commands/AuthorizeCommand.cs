using AllegroConnector.Application.Contracts;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class AuthorizeCommand : CommandBase<Result<SuccessfullyAuthorizedResponseMessage>>
    {
        public int Interval { get; set; }
        public string DeviceCode { get; set; }
    }
}
