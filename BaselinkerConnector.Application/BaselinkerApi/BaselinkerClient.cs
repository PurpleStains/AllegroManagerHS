using BaselinkerConnector.Application.Option;
using BaselinkerConnector.Domain;
using Microsoft.Extensions.Options;

namespace BaselinkerConnector.Application.BaselinkerApi
{
    public class BaselinkerClient(HttpClient client, IOptions<BaselinkerOption> options) : IBaselinkerClient
    {
        public HttpClient Client()
        {
            client.BaseAddress = new Uri("https://api.baselinker.com/connector.php");
            client.DefaultRequestHeaders.Add("X-BLToken", options.Value.Token);
            return client;
        }
    }
}
