using AllegroConnector.BuildingBlocks.Application.Events;
using BaselinkerConnector.Domain.Products.Events;
using Newtonsoft.Json;

namespace BaselinkerConnector.Application.Products.CreateProduct
{
    public class ProductCreatedNotification : DomainNotificationBase<ProductCreatedDomainEvent>
    {
        [JsonConstructor]
        public ProductCreatedNotification(ProductCreatedDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
