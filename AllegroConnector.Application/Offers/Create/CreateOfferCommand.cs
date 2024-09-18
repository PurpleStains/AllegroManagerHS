using AllegroConnector.Configuration;

namespace AllegroConnector.Application.Offers.Create
{
    public class CreateOfferCommand : InternalCommandBase
    {
        public CreateOfferCommand(Guid id, string offerId) : base(id) 
        { 
            OfferId = offerId;
        }
        internal string OfferId { get; set; }
    }
}
