using BaselinkerConnector.Domain;
using FluentResults;
using MediatR;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductDetailsRequestHandler : 
        IRequestHandler<GetProductDetailsRequest, Result<string>>
    {
        private readonly IBaselinkerClient _client;
        private const string Method = "getInventoryProductsData";

        public GetProductDetailsRequestHandler(IBaselinkerClient client)
        {
            _client = client;
        }

        public async Task<Result<string>> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "");
            message.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("method", Method),
                new KeyValuePair<string, string>("parameters", "{\"inventory_id\" : 54549, \"products\": [\"188176848\"]}")
            });

            var client = _client.Client();
            var response = await client.SendAsync(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            var products = await response.Content.ReadAsStringAsync();
            return Result.Ok(products);
        }
    }
}
