using BaselinkerConnector.Application.BaselinkerApi.Requests;
using BaselinkerConnector.Domain.Products;
using FluentResults;
using MediatR;
using Serilog;

namespace BaselinkerConnector.Application.Products
{
    public class ProductsService(IProductsRepository repository, IMediator mediator, ILogger logger) : IProductsService
    {
        public async Task ProcessProducts()
        {
            await LoadProducts();
        }

        private async Task<Result> LoadProducts()
        {
            logger.Information("Fetching products from baselinker...");
            var result = await mediator.Send(new GetProductsRequest());
            if (result.IsFailed)
            {
                logger.Error("Couldn't load products from baselinker", result.Errors);
                return Result.Fail(result.Errors);
            }

            foreach(var product in result.Value)
            {
                await AddOrUpdateProduct(product);
            }

            await repository.Commit();

            logger.Information("Fetched products.");

            return Result.Ok();
        }

        private async Task AddOrUpdateProduct(Product product)
        {
            if (await repository.GetByIdAsync(product.ProductId) is not null)
            {
                return;
            }

            var result = await mediator.Send(new GetProductDetailsRequest { ProductId = product.ProductId });
            if (result.IsFailed)
            {
                logger.Error($"Couldn't fetch product details with Ean: {product.Ean}", result.Errors);
                return;
            }

            product.Id = Guid.NewGuid();
            product.AverageGrossPriceBuy = result.Value.products.Values.First().average_cost;
            await repository.AddAsync(product);
        }
    }
}
