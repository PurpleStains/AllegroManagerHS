using AllegroConnector.BuildingBlocks.Domain;

namespace AllegroConnector.Domain.Offer.Events
{
    public class BuyPriceGrossUpdatedDomainEvent : DomainEventBase
    {
        public Guid OfferId { get; }

        public BuyPriceGrossUpdatedDomainEvent(Guid offerId)
        {
            OfferId = offerId;
        }
    }
}
