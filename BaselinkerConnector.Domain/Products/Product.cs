using AllegroConnector.BuildingBlocks.Domain;

namespace BaselinkerConnector.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public int ProductId { get; set; }
        public string Ean { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double AveragePrice { get; set; }
        public double AverageGrossPriceBuy { get; set; }

        private Product (int productId, string ean, string sku, string name, int stock, double averagePrice)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Ean = ean;
            Sku = sku;
            Name = name;
            Stock = stock;
            AveragePrice = averagePrice;
        }

        public static Product CreateNew(int productId, string ean, string sku, string name, int stock, double averagePrice)
        {
            return new Product(productId, ean, sku, name, stock, averagePrice);
        }

        public void SetAverageGrossPriceBuy(double price)
        {
            AverageGrossPriceBuy = price;
        }
    }
}
