using AllegroConnector.Application.Commands;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    internal class GetCodeCommandHandler(IAllegroOAuthService apiClient) : ICommandHandler<GetCodeCommand, AuthDeviceOAuth>
    {
        public async Task<AuthDeviceOAuth> Handle(GetCodeCommand request, CancellationToken cancellationToken)
        {
            var code = await apiClient.GetCode();
            return code.IsSuccess ? code.Value : null;
        }
    }
}
