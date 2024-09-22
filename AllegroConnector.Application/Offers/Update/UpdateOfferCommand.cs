using AllegroConnector.Configuration;
using Newtonsoft.Json;

namespace AllegroConnector.Application.Offers.Update
{
    public class UpdateOfferCommand : InternalCommandBase
    {
        public Guid OfferId { get; set; }

        [JsonConstructor]
        public UpdateOfferCommand(Guid id, Guid offerId) : base(id)
        {
            OfferId = offerId;
        }
    }
}
