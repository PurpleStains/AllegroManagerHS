using AllegroConnector.Domain.Models;
using BaselinkerConnector.Application.BaselinkerApi.Requests;
using BaselinkerConnector.Domain.Products;
using FluentResults;
using MediatR;
using Serilog;

namespace BaselinkerConnector.Application.Products
{
    public class ProductsService(IProductsRepository repository, IMediator mediator, ILogger logger) : IProductsService
    {
        public async Task<Result> LoadProducts()
        {
            var result = await mediator.Send(new GetProductsRequest());
            if (result.IsFailed)
            {
                logger.Error("Couldn't load products from baselinker", result.Errors);
                return Result.Fail(result.Errors);
            }

            return Result.Ok();
        }

        public Task UpdateProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
