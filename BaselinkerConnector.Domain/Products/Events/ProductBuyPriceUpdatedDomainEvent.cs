using AllegroConnector.BuildingBlocks.Domain;
using Newtonsoft.Json;

namespace BaselinkerConnector.Domain.Products.Events
{
    public class ProductBuyPriceUpdatedDomainEvent : DomainEventBase
    {
        public Guid ProductId { get; }
        public string ProductEan { get; }
        public double AverageBuyPriceGross { get; }

        [JsonConstructor]
        public ProductBuyPriceUpdatedDomainEvent(Guid productId, string productEan, double averageBuyPriceGross)
        {
            ProductId = productId;
            ProductEan = productEan;
            AverageBuyPriceGross = averageBuyPriceGross;
        }
    }
}
