using AllegroConnector.Domain.Models;

namespace AllegroConnector.Domain.Requests
{
    public class CalculateFeeRequest
    {
        public Models.Offer offer { get; set; }
        public ClassifiedsPackages classifiedsPackages { get; set; }
        public string marketplaceId { get; set; }
    }

    //public class Offer
    //{
    //    public FundraisingCampaign fundraisingCampaign { get; set; }
    //    public string id { get; set; }
    //    public Responses.Category category { get; set; }
    //    public List<Parameter> parameters { get; set; }
    //    public Promotion promotion { get; set; }
    //    public Publication publication { get; set; }
    //    public SellingMode sellingMode { get; set; }
    //}
}
