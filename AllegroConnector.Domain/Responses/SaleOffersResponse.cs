namespace AllegroConnector.Domain.Responses
{
    public class SaleOffersResponse
    {
        public List<Models.Offer> offers { get; set; }
        public int count { get; set; }
        public int totalCount { get; set; }
    }
}
