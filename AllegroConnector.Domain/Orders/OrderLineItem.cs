using AllegroConnector.Domain.Offer;

namespace AllegroConnector.Domain.Orders
{
    public class OrderLineItem
    {
        public Guid Id { get; private set; }
        public string OfferId { get; private set; }
        public string Quantity { get; private set; }
        public virtual AllegroOffer AllegroOffer { get; private set; }

        private OrderLineItem(Guid id, string offerId, string quantity)
        {
            Id = id;
            OfferId = offerId;
            Quantity = quantity;
        }

        public static OrderLineItem Create(Guid id, string offerId, string quantity)
        {
            var orderItem = new OrderLineItem(
                id,
                offerId,
                quantity);

            return orderItem;
        }

        public void SetAllegroOffer(AllegroOffer allegroOffer)
        {
            AllegroOffer = allegroOffer;
            OfferId = allegroOffer.OfferId;
        }
    }
}
