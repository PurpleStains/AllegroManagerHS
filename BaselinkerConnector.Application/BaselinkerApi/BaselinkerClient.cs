using BaselinkerConnector.Domain;
using Microsoft.Extensions.Options;

namespace BaselinkerConnector.Application.BaselinkerApi
{
    public class BaselinkerClient(HttpClient client) : IBaselinkerClient
    {
        private readonly string token = "4015149-4035230-Z8BEOJ9XKWZP5ALPNAWMH3Y628EEXSVOGBUJUX1MN6F4H6HWXVM6CP86VG5B4UTZ";

        public async Task<string> Products()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            request.Content = new FormUrlEncodedContent([
                new("method", "getInventoryProductsData"),
                new("parameters", "{\"inventory_id\" : 54549, \"products\": [\"188176848\"]}")
            ]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var products = await response.Content.ReadAsStringAsync();
            return products;
        }
    }
}
