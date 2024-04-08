namespace AllegroConnector.Domain.FeeCalculations
{
    public class OfferCalculations
    {
        public string OfferName { get; set; }
        public string AuctionId { get; set; }
        public string ProductEAN { get; set; }
        public FeeDetails FeeDetails { get; set; }
    }
}
