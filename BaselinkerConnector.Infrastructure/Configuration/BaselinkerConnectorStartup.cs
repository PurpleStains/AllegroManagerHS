using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroOAuth;
using Autofac;
using BaselinkerConnector.Application.BaselinkerApi;
using BaselinkerConnector.Domain;
using BaselinkerConnector.Infrastructure.Configuration.DataAccess;
using BaselinkerConnector.Infrastructure.Configuration.Logging;
using BaselinkerConnector.Infrastructure.Configuration.Mediation;
using Serilog;

namespace BaselinkerConnector.Infrastructure.Configuration
{
    public class BaselinkerConnectorStartup
    {
        static IContainer _container;
        public static void Initialize(
            string connectionString,
            string clientId,
            IHttpClientFactory httpClientFactory,
            ILogger logger,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "BaselinkerConnector");

            ConfigureCompositionRoot(
                connectionString,
                clientId,
                httpClientFactory,
                moduleLogger);
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
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterInstance(executionContextAccessor);

            containerBuilder.Register(ctx =>
            {
                var httpClientFactory = ctx.Resolve<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(nameof(BaselinkerClient));
                return new BaselinkerClient(httpClient);
            }).As<IBaselinkerClient>();

            _container = containerBuilder.Build();

            BaselinkerConnectorCompositionRoot.SetContainer(_container);
        }
    }
}
