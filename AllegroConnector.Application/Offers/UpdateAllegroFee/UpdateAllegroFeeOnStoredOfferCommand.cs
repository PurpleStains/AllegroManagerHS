using AllegroConnector.Configuration;
using Newtonsoft.Json;

namespace AllegroConnector.Application.Offers.UpdateAllegroFee
{
    public class UpdateAllegroFeeOnStoredOfferCommand : InternalCommandBase
    {
        public Guid OfferId { get; }

        [JsonConstructor]
        public UpdateAllegroFeeOnStoredOfferCommand(Guid id, Guid offerId) : base(id)
        {
            OfferId = offerId;
        }
    }
}
