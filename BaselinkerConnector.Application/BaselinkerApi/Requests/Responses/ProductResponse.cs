namespace BaselinkerConnector.Application.BaselinkerApi.Requests.Responses
{
    public class ProductResponse
    {
        public int id { get; set; }
        public string? ean { get; set; }
        public string? sku { get; set; }
        public string? name { get; set; }
        public Dictionary<string, int>? stock { get; set; }
        public Dictionary<string, double>? prices { get; set; }
    }
}
