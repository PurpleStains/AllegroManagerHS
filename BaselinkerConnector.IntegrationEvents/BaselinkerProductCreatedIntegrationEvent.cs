using AllegroConnector.BuildingBlocks.Infrastructure.EventBus;

namespace BaselinkerConnector.IntegrationEvents
{
    public class BaselinkerProductCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid ProductId { get; }
        public string ProductEan { get; }
        public double AverageBuyPriceGross { get; }

        public BaselinkerProductCreatedIntegrationEvent(
            Guid id,
            DateTime occurredOn,
            Guid productId,
            string productEan,
            double averageBuyPriceGross) 
            : base(id, occurredOn)
        {
            ProductId = productId;
            ProductEan = productEan;
            AverageBuyPriceGross = averageBuyPriceGross;
        }
    }
}
