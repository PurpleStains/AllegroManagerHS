using AllegroConnector.Configuration;
using Newtonsoft.Json;

namespace AllegroConnector.Application.Offers.Update
{
    public class UpdateOfferBuyPriceGrossCommand : InternalCommandBase<Guid>
    {
        [JsonConstructor]
        public UpdateOfferBuyPriceGrossCommand(
            Guid id,
            string productEan
            )
            : base(id)
        {
            ProductEan = productEan;
        }


        internal string ProductEan { get; }

    }
}
