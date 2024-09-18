using AllegroConnector.Application.Contracts;

namespace AllegroConnector.Application.Offers.ProcessOffers
{
    public class ProcessOffersCommand : CommandBase
    {
        //TODO move this to options file
        public int Offset { get; set; } = 100;
        public int Limit { get; set; } = 2000;
    }
}
