using AllegroConnector.BuildingBlocks.Domain;

namespace BaselinkerConnector.Domain.Products
{
    public class Product: Entity, IAggregateRoot 
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public string Ean { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double AveragePrice { get; set; }
        public double AverageGrossPriceBuy { get; set; }

        public static Product Create(int id, string ean, string sku, string name, int stock, double averagePrice)
        {
            return new Product
            {
                ProductId = id,
                Ean = ean,
                Sku = sku,
                Name = name,
                Stock = stock,
                AveragePrice = averagePrice
            };
        }
    }
}
