using AllegroConnector.Application.Contracts;
using FluentResults;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductDetailsRequest : HttpCallRequestBase<Result<string>> { }
}
