namespace BaselinkerConnector.Application.BaselinkerApi.Requests.Responses
{
    public class ProductDetail
    {
        public bool is_bundle { get; set; }
        public string? products { get; set; }
        public string? sku { get; set; }
        public double tax_rate { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public double star { get; set; }
        public int category_id { get; set; }
        public int manufacture_id { get; set; }
        public Dictionary<string, double>? prices { get; set; }
        public Dictionary<string, string>? locations { get; set; }
        public Dictionary<string, string>? links { get; set; }
        public double average_cost { get; set; }
        public double average_landed_cost { get; set; }
        public Dictionary<string, string>? images { get; set; }
    }
}
