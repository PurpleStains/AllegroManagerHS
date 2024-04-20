using AllegroConnector.Domain.Models;

namespace AllegroConnector.Domain.Requests
{
    public class CalculateFeeRequest
    {
        public Offer offer { get; set; }
        public ClassifiedsPackages classifiedsPackages { get; set; }
        public string marketplaceId = "allegro-pl";
    }

    public class Offer
    {
        public string id { get; set; }
        public string fundraisingCampaign = null;
        public string[] parameters = [];
        public Category category { get; set; }
        public SellingMode sellingMode { get; set; }
        public Publication publication { get; set; } = new();
    }

    public class Publication
    {
        public string duration { get; } = null;
        public string status { get; set; } = "ACTIVE";
        public string startingAt { get; set; } = null;
        public string endingAt { get; set; } = null;
        public string endedBy { get; set; } = null;
        public bool republish = false;
    }
}
