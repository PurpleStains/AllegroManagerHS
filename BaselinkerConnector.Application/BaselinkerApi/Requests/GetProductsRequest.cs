using AllegroConnector.Application.Contracts;
using BaselinkerConnector.Domain.Products;
using FluentResults;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductsRequest : HttpCallRequestBase<Result<List<Product>>> { }
}
