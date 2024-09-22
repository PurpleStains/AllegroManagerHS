using AllegroConnector.BuildingBlocks.Infrastructure.EventBus;
using BaselinkerConnector.IntegrationEvents;
using MediatR;

namespace BaselinkerConnector.Application.Products.UpdateProduct
{
    internal class ProductBuyPriceUpdatedNotificationHandler(IEventsBus eventsBus) 
        : INotificationHandler<ProductBuyPriceUpdatedNotification>
    {
        public async Task Handle(ProductBuyPriceUpdatedNotification notification, CancellationToken cancellationToken)
        {
            await eventsBus.Publish(new BaselinkerProductCreatedIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccurredOn,
                notification.DomainEvent.ProductId,
                notification.DomainEvent.ProductEan.ToString(),
                notification.DomainEvent.AverageBuyPriceGross));
        }
    }
}
