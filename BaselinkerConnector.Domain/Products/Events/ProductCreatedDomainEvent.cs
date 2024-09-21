using AllegroConnector.BuildingBlocks.Domain;

namespace BaselinkerConnector.Domain.Products.Events
{
    public class ProductCreatedDomainEvent : DomainEventBase
    {
        public Guid ProductId { get; }
        public int ProductEan { get; }

        public ProductCreatedDomainEvent(Guid productId, int productEan) {
            ProductId = productId;
            ProductEan = productEan;
        }
    }
}
