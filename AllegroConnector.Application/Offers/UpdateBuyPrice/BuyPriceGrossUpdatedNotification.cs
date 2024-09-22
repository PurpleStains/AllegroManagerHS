using AllegroConnector.BuildingBlocks.Application.Events;
using AllegroConnector.Domain.Offer.Events;
using Newtonsoft.Json;

namespace AllegroConnector.Application.Offers.UpdateBuyPrice
{
    public class BuyPriceGrossUpdatedNotification : DomainNotificationBase<BuyPriceGrossUpdatedDomainEvent>
    {
        [JsonConstructor]
        public BuyPriceGrossUpdatedNotification(BuyPriceGrossUpdatedDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
