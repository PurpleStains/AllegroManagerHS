using AllegroConnector.Infrastructure.Configuration.DataAccess;
using AllegroConnector.Infrastructure.Configuration.HttpClient;
using AllegroConnector.Infrastructure.Configuration.Logging;
using AllegroConnector.Infrastructure.Configuration.Mapper;
using AllegroConnector.Infrastructure.Configuration.Mediation;
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
            //IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "AllegroConnector");

            ConfigureCompositionRoot(
                connectionString,
                clientId,
                httpClientFactory,
                moduleLogger);
        }

        public static void Stop()
        {
           //quartz stop
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            string clientId,
            IHttpClientFactory executionContextAccessor,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new LoggingModule(logger));

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            //containerBuilder.RegisterModule(new ProcessingModule());
            //containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new AllegroClientModule(clientId));
            //containerBuilder.RegisterModule(new AuthenticationModule());
            containerBuilder.RegisterInstance(executionContextAccessor);
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
