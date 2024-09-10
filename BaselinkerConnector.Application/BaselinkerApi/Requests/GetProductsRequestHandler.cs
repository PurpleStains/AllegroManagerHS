using BaselinkerConnector.Application.BaselinkerApi.Requests.Responses;
using BaselinkerConnector.Domain;
using BaselinkerConnector.Domain.Products;
using FluentResults;
using MediatR;
using System.Text.Json;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductsRequestHandler(IBaselinkerClient client)
        : IRequestHandler<GetProductsRequest, Result<List<Product>>>
    {
        private const string Method = "getInventoryProductsList";

        public async Task<Result<List<Product>>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "");
            message.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("method", Method),
                new KeyValuePair<string, string>("parameters", "{\"inventory_id\" : 54549}")
            });

            var response = await client.Client().SendAsync(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ProductsResponse>(content);

            var products = result?.products.Values.Select(x => Product
                .Create(x.id, x.ean, x.sku, x.name, x.stock.First().Value, x.prices.First().Value))
                .ToList();

            return Result.Ok(products ?? []);
        }
    }
}
