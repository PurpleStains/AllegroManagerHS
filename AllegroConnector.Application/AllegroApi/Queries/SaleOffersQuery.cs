using AllegroConnector.Application.Contracts;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    public class SaleOffersQuery : QueryBase<SaleOffersResponse>
    {
        public string Limit { get; set; }

        public string Offset { get; set; }

        public SaleOffersQuery(string limit, string offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
