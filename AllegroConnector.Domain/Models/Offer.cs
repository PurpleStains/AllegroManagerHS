namespace AllegroConnector.Domain.Models
{
    public class Offer
    {
        public string id { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public PrimaryImage primaryImage { get; set; }
        public SellingMode sellingMode { get; set; }
        public SaleInfo saleInfo { get; set; }
        public Stats stats { get; set; }
        public Stock stock { get; set; }
        public Publication publication { get; set; }
        public AfterSalesServices afterSalesServices { get; set; }
        public AdditionalServices additionalServices { get; set; }
        public External external { get; set; }
        public Delivery delivery { get; set; }
        public B2b b2b { get; set; }
        public FundraisingCampaign fundraisingCampaign { get; set; }
    }

}
