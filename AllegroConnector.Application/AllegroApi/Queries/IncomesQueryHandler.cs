using AllegroConnector.Application.Queries;
using AllegroConnector.Domain.Orders;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class IncomesQueryHandler(IAllegroOrdersRepository ordersRepository)
        : IQueryHandler<IncomesQuery, IncomesResponse>
    {
        public async Task<IncomesResponse> Handle(IncomesQuery query, CancellationToken cancellationToken)
        {
            var orders = await ordersRepository.Get();
            var filtered = orders
                .Where(x => x.UpdatedAt > query.From && x.UpdatedAt < query.To);

            var sum = filtered
                .Sum(x => double.Parse(x.Margin));

            return new IncomesResponse()
            {
                TotalOrders = filtered.Count(),
                Incomes = sum.ToString()
            };
        }
    }
}
