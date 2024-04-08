using AllegroConnector.Application.Contracts;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class AuthorizeCommand : CommandBase
    {
        public int Interval { get; set; }
        public string DeviceCode { get; set; }
    }
}
