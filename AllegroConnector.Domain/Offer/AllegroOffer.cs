using AllegroConnector.Domain.Orders;

namespace AllegroConnector.Domain.Offer
{
    public class AllegroOffer
    {
        public Guid AllegroOfferId { get; private set; }
        public string OfferId { get; private set; }
        public string CategoryId { get; private set; }
        public string EAN { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public string PublicationStatus { get; private set; }
        public string? PriceGross { get; private set; }

        public virtual ICollection<OrderLineItem> OrderLineItems { get; private set; } = new List<OrderLineItem>();

        public AllegroOffer() { }
        private AllegroOffer(
            Guid allegroOfferId,
            string offerId,
            string categoryId,
            string ean,
            string name,
            int stock,
            string publicationStatus,
            string priceGross
            )
        {
            AllegroOfferId = allegroOfferId;
            OfferId = offerId;
            CategoryId = categoryId;
            EAN = ean;
            Name = name;
            Stock = stock;
            PublicationStatus = publicationStatus;
            PriceGross = priceGross;
        }

        public static AllegroOffer Create(
            Guid allegroOfferId,
            string offerId,
            string categoryId,
            string ean,
            string name,
            int stock,
            string publicationStatus,
            string priceGross)
        {
            var offer = new AllegroOffer(
            allegroOfferId,
            offerId,
            categoryId,
            ean,
            name,
            stock,
            publicationStatus,
            priceGross);

            return offer;
        }

    }
}
