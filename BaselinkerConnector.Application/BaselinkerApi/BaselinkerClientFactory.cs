using BaselinkerConnector.Application.Option;
using BaselinkerConnector.Domain;
using Microsoft.Extensions.Options;

namespace BaselinkerConnector.Application.BaselinkerApi
{
    public class BaselinkerClientFactory(HttpClient client, IOptions<BaselinkerOption> options) : IBaselinkerClientFactory
    {
        public HttpClient Client()
        {
            client.BaseAddress = new Uri("https://api.baselinker.com/connector.php");
            client.DefaultRequestHeaders.Add("X-BLToken", options.Value.Token);
            return client;
        }
    }
}
