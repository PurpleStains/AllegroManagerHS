using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Models.Billings;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    public class OrdersBillingQuery : QueryBase<BillingEntries>
    {
        public OrdersBillingQuery(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
