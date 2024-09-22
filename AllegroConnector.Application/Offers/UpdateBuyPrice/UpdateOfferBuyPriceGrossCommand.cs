using AllegroConnector.Configuration;
using Newtonsoft.Json;

namespace AllegroConnector.Application.Offers.UpdateBuyPrice
{
    public class UpdateOfferBuyPriceGrossCommand : InternalCommandBase
    {
        [JsonConstructor]
        public UpdateOfferBuyPriceGrossCommand(
            Guid id,
            string productEan,
            double buyPrice
            )
            : base(id)
        {
            ProductEan = productEan;
            BuyPrice = buyPrice;
        }


        internal string ProductEan { get; }
        internal double BuyPrice { get; }

    }
}
