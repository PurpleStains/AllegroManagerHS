using BaselinkerConnector.Application.BaselinkerApi.Requests.Responses;
using BaselinkerConnector.Application.Contracts;
using FluentResults;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductsRequest : CommandBase<Result<ProductsResponse>> { }
}
