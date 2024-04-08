using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.Orders;
using System.Globalization;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class OrderBillingQueryHandler(IAllegroApiClient apiClient, IAllegroOrdersRepository ordersRepository)
        : IQueryHandler<OrdersBillingQuery, BillingEntries>
    {
        public async Task<BillingEntries> Handle(OrdersBillingQuery request, CancellationToken cancellationToken)
        {
            var csvReader = new CsvGenericWriter();
            var products = csvReader.Products();
            var orders = await ordersRepository.Get();
            var filtered = orders.Where(x => x.UpdatedAt > request.From && x.UpdatedAt < request.To);
            foreach (var order in filtered)
            {
                var calculatedNetPrice = SummedPriceNet(order.LineItems);
                var sumProductsGrossPrice = order.LineItems
                    .Sum(x => double.Parse(x.AllegroOffer.PriceGross, CultureInfo.InvariantCulture)
                     * int.Parse(x.Quantity, CultureInfo.InvariantCulture));

                var sumMargin = sumProductsGrossPrice
                    - calculatedNetPrice
                    + double.Parse(order.AllegroFee, NumberStyles.Any, CultureInfo.CurrentCulture);

                order.SetMargin(sumMargin.ToString());
                await ordersRepository.Update(order);
                await ordersRepository.Commit();
            }

            double? SummedPriceNet(ICollection<OrderLineItem> items)
            {
                double? sum = 0;
                foreach (var item in items)
                {
                    var fromList = products.FirstOrDefault(x => x.auction_id.Equals(item.OfferId))?.price;
                    if (fromList is null) { continue; }
                    sum += fromList * int.Parse(item.Quantity, CultureInfo.InvariantCulture);
                }

                return sum;
            }
            return new BillingEntries();
        }
    }
}
