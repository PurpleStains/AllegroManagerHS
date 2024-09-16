using BaselinkerConnector.Application.BaselinkerApi.Requests.Responses;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Option;
using BaselinkerConnector.Domain;
using FluentResults;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BaselinkerConnector.Application.BaselinkerApi.Requests
{
    public class GetProductDetailsRequestHandler(IBaselinkerClient client, IOptions<BaselinkerOption> options) : 
        ICommandHandler<GetProductDetailsRequest, Result<ProductsDetailsResponse>>
    {

        private const string Method = "getInventoryProductsData";

        public async Task<Result<ProductsDetailsResponse>> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(options.Value.InventoryId))
            {
               return Result.Fail("Missing Inventory Id");
            }

            var message = new HttpRequestMessage(HttpMethod.Post, "");

            string jsonString = $"{{\"inventory_id\" : {options.Value.InventoryId}, \"products\": [\"{request.ProductId}\"]}}";
            message.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("method", Method),
                new KeyValuePair<string, string>("parameters", jsonString)
            });

            var response = await client.Client().SendAsync(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ProductsDetailsResponse>(content);
            if (result is null)
            {
                return Result.Fail("Result response was empty");
            }

            if (result?.status?.Equals("ERROR") == true)
            {
                return Result.Fail($"Status: {result?.status} ErrorCode: {result?.error_code} Message: {result?.error_message}");
            }

            return Result.Ok(result);
        }
    }
}
