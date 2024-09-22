using AllegroConnector.BuildingBlocks.Application.Events;
using BaselinkerConnector.Domain.Products.Events;
using Newtonsoft.Json;

namespace BaselinkerConnector.Application.Products.UpdateProduct
{
    public class ProductBuyPriceUpdatedNotification : DomainNotificationBase<ProductBuyPriceUpdatedDomainEvent>
    {
        [JsonConstructor]
        public ProductBuyPriceUpdatedNotification(ProductBuyPriceUpdatedDomainEvent domainEvent, Guid id)
            : base(domainEvent, id)
        {
        }
    }
}
