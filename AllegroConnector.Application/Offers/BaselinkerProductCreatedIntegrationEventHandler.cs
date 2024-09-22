using AllegroConnector.Application.Commands;
using AllegroConnector.Application.Offers.UpdateBuyPrice;
using BaselinkerConnector.IntegrationEvents;
using MediatR;

namespace AllegroConnector.Application.Offers
{
    public class BaselinkerProductCreatedIntegrationEventHandler(ICommandsScheduler commandsScheduler) :
        INotificationHandler<BaselinkerProductCreatedIntegrationEvent>
    {

        public async Task Handle(BaselinkerProductCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await commandsScheduler.EnqueueAsync(new
                UpdateOfferBuyPriceGrossCommand(Guid.NewGuid(), notification.ProductEan, notification.AverageBuyPriceGross));
        }
    }
}
