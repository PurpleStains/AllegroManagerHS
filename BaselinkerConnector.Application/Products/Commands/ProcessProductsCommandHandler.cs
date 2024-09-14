using AllegroConnector.Application.Commands;
using BaselinkerConnector.Domain.Products;
using Serilog;

namespace BaselinkerConnector.Application.Products.Commands
{
    public class ProcessProductsCommandHandler(IProductsService service, ILogger logger) : ICommandHandler<ProcessProductsCommand>
    {
        public async Task Handle(ProcessProductsCommand request, CancellationToken cancellationToken)
        {
            logger.Information($"Processing products execution started at: {DateTime.UtcNow}");

            await service.ProcessProducts();

            logger.Information($"Processing products execution finished at: {DateTime.UtcNow}");
        }
    }
}
