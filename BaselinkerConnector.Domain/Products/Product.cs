using AllegroConnector.BuildingBlocks.Domain;

namespace BaselinkerConnector.Domain.Products
{
    public class Product : Entity, IAggregateRoot 
    {
        public int Id { get; set; }
        public string Ean { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double AveragePrice { get; set; }
    }
}
