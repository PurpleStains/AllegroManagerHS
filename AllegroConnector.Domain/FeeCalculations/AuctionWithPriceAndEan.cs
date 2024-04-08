namespace AllegroConnector.Domain
{
    public class AuctionWithPriceAndEan
    {
        public string auction_id { get; set; }
        public string products_ean { get; set; }
        public double price { get; set; }
    }
}
