using AllegroConnector.Domain.FeeCalculations;

namespace AllegroConnector.Domain.Responses
{
    public class OffersFeeResponse
    {
        public List<OfferCalculations> Calculations { get; set; }
    }
}
