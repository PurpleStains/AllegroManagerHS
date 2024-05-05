using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    public class IncomesQuery : QueryBase<IncomesResponse>
    {
        public IncomesQuery(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
