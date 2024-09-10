using AllegroConnector.Application.Contracts;
using FluentResults;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductsRequest : HttpCallRequestBase<Result<string>> { }
}
