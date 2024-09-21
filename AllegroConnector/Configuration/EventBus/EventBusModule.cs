using AllegroConnector.BuildingBlocks.Infrastructure.EventBus;
using Autofac;

namespace AllegroConnector.Infrastructure.Configuration.EventBus
{
    internal class EventsBusModule : Module
    {
        private readonly IEventsBus _eventsBus;

        public EventsBusModule(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_eventsBus != null)
            {
                builder.RegisterInstance(_eventsBus).SingleInstance();
            }
            else
            {
                builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
            }
        }
    }
}
