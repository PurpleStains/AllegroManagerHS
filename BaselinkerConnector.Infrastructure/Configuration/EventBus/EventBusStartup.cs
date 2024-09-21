using AllegroConnector.BuildingBlocks.Infrastructure.EventBus;
using Autofac;
using Serilog;

namespace BaselinkerConnector.Infrastructure.Configuration.EventBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(
            ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = BaselinkerConnectorCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            //SubscribeToIntegrationEvent<BaselinkerProductCreatedIntegrationEvent>(eventBus, logger);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
            where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(new IntegrationEventGenericHandler<T>());
        }
    }
}
