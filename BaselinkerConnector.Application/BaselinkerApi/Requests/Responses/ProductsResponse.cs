namespace BaselinkerConnector.Application.BaselinkerApi.Requests.Responses
{
    public class ProductsResponse
    {
        public string? status { get; set; }
        public Dictionary<long, ProductResponse>? products { get; set; }
    }
}
