using AllegroConnector.Application.Commands;
using FluentResults;

namespace AllegroConnector.Application.AllegroAuthorization.Commands
{
    internal class GetCodeCommandHandler(IAllegroOAuthService apiClient) : ICommandHandler<GetCodeCommand, Result<SuccessfullyGetCodeMessage>>
    {
        public async Task<Result<SuccessfullyGetCodeMessage>> Handle(GetCodeCommand request, CancellationToken cancellationToken)
        {
            var result = await apiClient.GetCode();
            if (result.IsSuccess)
            {
                return Result.Ok(new SuccessfullyGetCodeMessage(result.Value.device_code, result.Value.verification_uri_complete));
            }
            return Result.Fail("Failed to get device code");
        }
    }
}
