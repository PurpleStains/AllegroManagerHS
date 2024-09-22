using AllegroConnector.Application.Commands;
using AllegroConnector.Application.Offers.UpdateAllegroFee;
using MediatR;

namespace AllegroConnector.Application.Offers.UpdateBuyPrice
{
    internal class BuyPriceGrossUpdatedNotificationHandler(
        ICommandsScheduler scheduler)
        : INotificationHandler<BuyPriceGrossUpdatedNotification>
    {
        public async Task Handle(BuyPriceGrossUpdatedNotification notification, CancellationToken cancellationToken)
        {
            await scheduler.EnqueueAsync(new
                UpdateAllegroFeeOnStoredOfferCommand
                (Guid.NewGuid(), notification.DomainEvent.OfferId));
        }
    }
}
