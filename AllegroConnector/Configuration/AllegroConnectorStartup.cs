using AllegroConnector.Application.Offers.Create;
using AllegroConnector.Application.Offers.Update;
using AllegroConnector.Application.Validation;
using AllegroConnector.BuildingBlocks.Infrastructure;
using AllegroConnector.BuildingBlocks.Infrastructure.EventBus;
using AllegroConnector.Domain.EAN;
using AllegroConnector.Infrastructure.Configuration.DataAccess;
using AllegroConnector.Infrastructure.Configuration.EventBus;
using AllegroConnector.Infrastructure.Configuration.HttpClient;
using AllegroConnector.Infrastructure.Configuration.Logging;
using AllegroConnector.Infrastructure.Configuration.Mapper;
using AllegroConnector.Infrastructure.Configuration.Mediation;
using AllegroConnector.Infrastructure.Configuration.Processing;
using AllegroConnector.Infrastructure.Configuration.Processing.InternalCommands;
using AllegroConnector.Infrastructure.Configuration.Processing.Outbox;
using AllegroConnector.Infrastructure.Configuration.Quartz;
using Autofac;
using AutoMapper;
using Serilog;

namespace AllegroConnector.Infrastructure.Configuration
{
    public class AllegroConnectorStartup
    {
        static IContainer _container;
        public static void Initialize(
            string connectionString,
            string clientId,
            IHttpClientFactory httpClientFactory,
            ILogger logger,
            IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "AllegroConnector");

            ConfigureCompositionRoot(
                connectionString,
                clientId,
                httpClientFactory,
                moduleLogger,
                eventsBus);

            QuartzStartup.Initialize(logger, _container);

            EventsBusStartup.Initialize(moduleLogger);
        }

        public static void Stop()
        {
           //quartz stop
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            string clientId,
            IHttpClientFactory executionContextAccessor,
            ILogger logger,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new LoggingModule(logger));

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new AllegroClientModule(clientId));

            BiDictionary<string, Type> internalCommandsMap = new BiDictionary<string, Type>();
            internalCommandsMap.Add("CreateOfferCommand", typeof(CreateOfferCommand));
            internalCommandsMap.Add("UpdateOfferBuyPriceGrossCommand", typeof(UpdateOfferBuyPriceGrossCommand));
            containerBuilder.RegisterModule(new InternalCommandsModule(internalCommandsMap));
            var domainNotificationsMap = new BiDictionary<string, Type>();
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
            containerBuilder.RegisterModule(new QuartzModule());

            //containerBuilder.RegisterModule(new AuthenticationModule());
            containerBuilder.RegisterInstance(executionContextAccessor);

            // Custom registration
            containerBuilder.RegisterType<EANValidator>().As<IEANValidator>().InstancePerDependency();

            RegisterMapper(containerBuilder);

            _container = containerBuilder.Build();

            AllegroConnectorCompositionRoot.SetContainer(_container);
        }

        private static void RegisterMapper(ContainerBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuthorizationMapperProfile>();
            });

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
        }
    }
}
