using AllegroConnector.Application.Contracts;
using BaselinkerConnector.Application.BaselinkerApi.Requests.Responses;
using FluentResults;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductDetailsRequest : HttpCallRequestBase<Result<ProductsDetailsResponse>> 
    { 
        public int ProductId { get; set; }
    }
}
