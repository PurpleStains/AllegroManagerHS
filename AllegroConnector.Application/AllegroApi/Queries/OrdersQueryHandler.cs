using AllegroConnector.Application.Queries;
using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Orders;
using System.Globalization;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class OrdersQueryHandler : IQueryHandler<OrdersQuery, CheckoutFormResponse>
    {
        readonly IAllegroOrdersRepository _ordersRepository;

        public OrdersQueryHandler(IAllegroOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<CheckoutFormResponse> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _ordersRepository.Get();

            var toCalculate = result.Where(x => x.UpdatedAt >= new DateTimeOffset(2024, 3, 1, 0, 0,0, new TimeSpan())
            && x.UpdatedAt <= new DateTimeOffset(2024, 3, 31, 0, 0, 0, new TimeSpan()))
                .ToList()
                .Sum(x => double.Parse(x.Margin, NumberStyles.Any, CultureInfo.CurrentCulture));

            var totalToPay = result.Where(x => x.UpdatedAt >= new DateTimeOffset(2024, 3, 1, 0, 0, 0, new TimeSpan())
            && x.UpdatedAt <= new DateTimeOffset(2024, 3, 31, 0, 0, 0, new TimeSpan()))
                .ToList()
                .Sum(x => double.Parse(x.TotalToPay, CultureInfo.InvariantCulture));
            return new CheckoutFormResponse();
        }
    }
}
