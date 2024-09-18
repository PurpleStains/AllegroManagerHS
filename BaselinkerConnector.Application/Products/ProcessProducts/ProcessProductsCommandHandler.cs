using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Domain.Products;
using Serilog;

namespace BaselinkerConnector.Application.Products.Commands
{
    public class ProcessProductsCommandHandler(IProductsService service, ILogger logger) : ICommandHandler<ProcessProductsCommand>
    {
        public async Task Handle(ProcessProductsCommand request, CancellationToken cancellationToken)
        {
            await service.ProcessProducts();
        }
    }
}
