namespace BaselinkerConnector.Application.BaselinkerApi.Requests.Responses
{
    public class ProductsDetailsResponse
    {
        public string? status { get; set; }
        public string? error_code { get; set; }
        public string? error_message { get; set; }
        public Dictionary<string, ProductDetail>? products { get; set; }
    }
}
