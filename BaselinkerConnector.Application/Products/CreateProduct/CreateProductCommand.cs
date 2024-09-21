using BaselinkerConnector.Application.Configuration.Commands;
using Newtonsoft.Json;

namespace BaselinkerConnector.Application.Products.CreateProduct
{
    public class CreateProductCommand : InternalCommandBase
    {
        [JsonConstructor]
        public CreateProductCommand(Guid id, int productId, string ean, string sku, string name, int stock,
            double averagePrice) : base(id)
        {
            ProductId = productId;
            Ean = ean;
            Sku = sku;
            Name = name;
            Stock = stock;
            AveragePrice = averagePrice;
        }

        public int ProductId { get; set; }
        public string Ean { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double AveragePrice { get; set; }
    }
}
