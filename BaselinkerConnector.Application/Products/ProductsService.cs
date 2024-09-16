using BaselinkerConnector.Application.BaselinkerApi.Requests;
using BaselinkerConnector.Application.BaselinkerApi.Requests.Responses;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Products.CreateProduct;
using BaselinkerConnector.Domain.Products;
using FluentResults;
using MediatR;
using Serilog;

namespace BaselinkerConnector.Application.Products
{
    public class ProductsService(IProductsRepository repository, ICommandsScheduler commandsScheduler, IMediator mediator, ILogger logger) : IProductsService
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

            foreach(var product in result.Value.products)
            {
                await AddOrUpdateProduct(product.Value);
            }

            await repository.Commit();

            logger.Information("Fetched products.");

            return Result.Ok();
        }

        private async Task AddOrUpdateProduct(ProductResponse product)
        {
            if (await repository.GetByIdAsync(product.id) is not null)
            {
                return;
            }

            var command = new CreateProductCommand(
                Guid.NewGuid(),
                product.id,
                product.ean,
                product.sku,
                product.name,
                product.stock.Values.First(),
                product.prices.Values.First());

            await commandsScheduler.EnqueueAsync(command);
            //var result = await mediator.Send(new GetProductDetailsRequest { ProductId = product.ProductId });
            //if (result.IsFailed)
            //{
            //    logger.Error($"Couldn't fetch product details with Ean: {product.Ean}", result.Errors);
            //    return;
            //}

            //product.SetAverageGrossPriceBuy(result.Value.products.Values.First().average_cost);
        }
    }
}
