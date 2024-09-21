using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Products.UpdateProduct;
using MediatR;

namespace BaselinkerConnector.Application.Products.CreateProduct
{
    internal class ProductCreatedNotificationHandler
        (ICommandsScheduler commandsScheduler) 
        : INotificationHandler<ProductCreatedNotification>
    {
        public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            await commandsScheduler.EnqueueAsync(new UpdateProductCommand(Guid.NewGuid(), notification.DomainEvent.ProductId));
        }
    }
}
