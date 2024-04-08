using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    public class OfferQuery : QueryBase<ConcreteProductOfferResponse>
    {
        public string OfferId { get; }

        public OfferQuery(string offerId)
        {
            OfferId = offerId;
        }
    }
}
