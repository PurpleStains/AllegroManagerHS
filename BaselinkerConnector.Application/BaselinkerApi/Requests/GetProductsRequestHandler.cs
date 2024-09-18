using BaselinkerConnector.Application.BaselinkerApi.Requests.Responses;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Domain;
using FluentResults;
using MediatR;
using Serilog;
using System.Text.Json;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductsRequestHandler(IBaselinkerClientFactory client, ILogger logger)
        : ICommandHandler<GetProductsRequest, Result<ProductsResponse>>
    {
        private const string Method = "getInventoryProductsList";

        public async Task<Result<ProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
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
            if (string.IsNullOrEmpty(content))
            {
                return Result.Fail($"Response for {Method} was empty");
            }

            var result = JsonSerializer.Deserialize<ProductsResponse>(content);

            return Result.Ok(result);
        }
    }
}
