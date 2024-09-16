using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Domain.Products;

namespace BaselinkerConnector.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler(IProductsRepository repository) : ICommandHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isExisting = await repository.GetByIdAsync(request.ProductId);
            if (isExisting is not null) return;

            var product = Product.CreateNew(
                request.ProductId,
                request.Ean,
                request.Sku,
                request.Name,
                request.Stock,
                request.AveragePrice);

            await repository.AddAsync(product);
        }
    }
}
