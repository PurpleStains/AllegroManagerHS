using AllegroConnector.Domain.Orders;

namespace AllegroConnector.Domain.Responses
{
    public class OrdersResponse
    {
        public List<Order> Orders { get; set; }
        public double TotalToPay { get; set; }
    }
}
