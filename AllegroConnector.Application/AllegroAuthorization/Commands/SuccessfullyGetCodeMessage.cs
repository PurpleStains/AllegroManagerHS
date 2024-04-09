using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    public class SuccessfullyGetCodeMessage : Success
    {
        public SuccessfullyGetCodeMessage(string deviceCode, string verificationUriComplete) : base(deviceCode)
        {
            DeviceCode = deviceCode;
            VerificationUriComplete = verificationUriComplete;
        }
        public string DeviceCode{ get; }
        public string VerificationUriComplete { get; }
    }
}
