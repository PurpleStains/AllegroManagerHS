using AllegroConnector.Domain.Models;

namespace AllegroConnector.Domain.Responses
{
    public class OfferResponse
    {
        public Models.Offer offer { get; set; }
        public ClassifiedsPackages classifiedsPackages { get; set; }
        public string marketplaceId { get; set; }
    }

}
