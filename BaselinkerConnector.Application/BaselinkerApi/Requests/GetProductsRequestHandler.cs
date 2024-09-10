using BaselinkerConnector.Domain;
using FluentResults;
using MediatR;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductsRequestHandler(IBaselinkerClient client) : IRequestHandler<GetProductsRequest, Result<string>>
    {
        private const string Method = "getInventoryProductsList";

        public async Task<Result<string>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "");
            message.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("method", Method),
                new KeyValuePair<string, string>("parameters", "{\"inventory_id\" : 54549}")
            });

            var response = await client.Client().SendAsync(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            var products = await response.Content.ReadAsStringAsync();
            return Result.Ok(products);
        }
    }
}
