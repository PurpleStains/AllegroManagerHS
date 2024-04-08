namespace AllegroConnector.Domain.FeeCalculations
{
    public class FeeDetails
    {
        public string AuctionPrice { get; set; }
        public double BuyPrice { get; set; }
        public double BasisFee { get; set; }
        public double PackageFee { get; set; }
        public double Income { get; set; }
        public double Margin { get; set; }
    }
}
