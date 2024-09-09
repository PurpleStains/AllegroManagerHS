using AllegroConnector.Application.Commands;
using BaselinkerConnector.Domain;
using FluentResults;

namespace BaselinkerConnector.Application.BaselinkerApi.Commands
{
    public class GetBaselinkerProductsCommandHandler(IBaselinkerClient client)
        : ICommandHandler<GetBaselinkerProductsCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(GetBaselinkerProductsCommand request, CancellationToken cancellationToken)
        {
            var result = await client.Products();

            return Result.Ok(result);
        }
    }
}
