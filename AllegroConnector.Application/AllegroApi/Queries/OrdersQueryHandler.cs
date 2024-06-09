using AllegroConnector.Application.Queries;
using AllegroConnector.Domain.Orders;
using AllegroConnector.Domain.Responses;
using System.Globalization;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class OrdersQueryHandler : IQueryHandler<OrdersQuery, OrdersResponse>
    {
        readonly IAllegroOrdersRepository _ordersRepository;

        public OrdersQueryHandler(IAllegroOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<OrdersResponse> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _ordersRepository.Get();

            var toCalculate = result.Where(x => x.UpdatedAt >= new DateTimeOffset(2024, 3, 1, 0, 0,0, new TimeSpan())
            && x.UpdatedAt <= new DateTimeOffset(2024, 3, 31, 0, 0, 0, new TimeSpan()))
                .ToList()
                .Sum(x => x?.Margin is not null ? double.Parse(x?.Margin, NumberStyles.Any, CultureInfo.CurrentCulture) : 0);

            var totalToPay = result.Where(x => x.UpdatedAt >= new DateTimeOffset(2024, 3, 1, 0, 0, 0, new TimeSpan())
            && x.UpdatedAt <= new DateTimeOffset(2024, 3, 31, 0, 0, 0, new TimeSpan()))
                .ToList()
                .Sum(x => x?.TotalToPay is not null ? double.Parse(x?.TotalToPay, CultureInfo.InvariantCulture) : 0);

            return new OrdersResponse()
            {
                Orders = result.ToList(),
                TotalToPay = totalToPay,
            };
        }
    }
}
