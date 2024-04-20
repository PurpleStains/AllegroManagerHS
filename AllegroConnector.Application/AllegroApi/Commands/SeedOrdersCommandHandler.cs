using AllegroConnector.Application.Commands;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Models;
using AllegroConnector.Domain.Models.Billings;
using AllegroConnector.Domain.Offer;
using AllegroConnector.Domain.Orders;
using System.Globalization;

namespace AllegroConnector.Application.AllegroApi.Commands
{
    internal class SeedOrdersCommandHandler(IAllegroApiService allegroClient,
            IAllegroOrdersRepository ordersRepository,
            IAllegroOffersRepository offersRepository) : ICommandHandler<SeedOrdersCommand, CheckoutFormResponse>
    {

        public async Task<CheckoutFormResponse> Handle(SeedOrdersCommand query, CancellationToken cancellationToken)
        {
            var result = await allegroClient.GetOrders(query.Limit, query.Offset);
            foreach (var allegroOrder in result.checkoutForms)
            {
                var billing = await allegroClient.GetBillingForOrder(allegroOrder.Id);
                var orderItems = await CreateOrderLineItems(allegroOrder.LineItems);
                var order = Domain.Orders.Order.Create(allegroOrder.Id,
                    allegroOrder.Buyer.Email,
                    allegroOrder.Buyer.FirstName,
                    allegroOrder.Buyer.LastName,
                    allegroOrder.Buyer.Login,
                    allegroOrder.Summary.TotalToPay.Amount,
                    allegroOrder.Status,
                    SumFee(billing.billingEntries),
                    allegroOrder.UpdatedAt);
                order.AddOrderLineItems(orderItems);

                if (await ordersRepository.GetByIdAsync(order.Id) is null)
                {
                    await ordersRepository.AddAsync(order);
                }
            }

            await ordersRepository.Commit();
            return result;

            string SumFee(List<BillingEntry> entries)
            {
                return entries.Sum(x => double.Parse(x.value.amount, CultureInfo.InvariantCulture)).ToString();
            }
        }

        async Task<List<Domain.Orders.OrderLineItem>> CreateOrderLineItems(ICollection<Domain.Models.OrderLineItem> items)
        {
            var result = new List<Domain.Orders.OrderLineItem>();
            foreach (var item in items)
            {
                var orderItem = Domain.Orders.OrderLineItem.Create(item.Id, item.Offer.id, item.Quantity.ToString());
                var offer = await offersRepository.GetByIdAsync(item.Offer.id);
                if (offer is not null)
                {
                    orderItem.SetAllegroOffer(offer);
                    result.Add(orderItem);
                }
            }

            return result;
        }
    }
}
