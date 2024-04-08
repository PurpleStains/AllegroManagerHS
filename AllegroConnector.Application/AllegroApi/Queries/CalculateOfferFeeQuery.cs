using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    public class CalculateOfferFeeQuery : QueryBase<OffersFeeResponse>
    {
        public string OfferId { get; }
        public CalculateOfferFeeQuery(string offerId)
        {
            OfferId = offerId;
        }
    }
}
