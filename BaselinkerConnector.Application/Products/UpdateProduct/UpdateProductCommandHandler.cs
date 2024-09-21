using BaselinkerConnector.Application.BaselinkerApi.Requests;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Domain.Products;
using MediatR;

namespace BaselinkerConnector.Application.Products.UpdateProduct
{
    internal class UpdateProductCommandHandler(IProductsRepository productsRepository, IMediator mediator) : ICommandHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productsRepository.GetByIdAsync(request.ProductId);
            if (product == null) return;

            var response = await mediator.Send(new GetProductDetailsRequest() { ProductId = product.ProductId }, cancellationToken);
            if(response.IsFailed) return;
            

            var averageCost = response.Value.products.FirstOrDefault().Value.average_cost;
            if (averageCost == 0) return;

            product.SetAverageGrossPriceBuy(response.Value.products.FirstOrDefault().Value.average_cost);
            
        }
    }
}
