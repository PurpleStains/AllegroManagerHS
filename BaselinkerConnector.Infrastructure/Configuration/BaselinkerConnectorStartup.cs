using Autofac;
using BaselinkerConnector.Application.BaselinkerApi;
using BaselinkerConnector.Application.Option;
using BaselinkerConnector.Domain;
using BaselinkerConnector.Infrastructure.Configuration.DataAccess;
using BaselinkerConnector.Infrastructure.Configuration.Logging;
using BaselinkerConnector.Infrastructure.Configuration.Mediation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

namespace BaselinkerConnector.Infrastructure.Configuration
{
    public class BaselinkerConnectorStartup
    {
        static IContainer _container;
        public static void Initialize(
            string connectionString,
            string clientId,
            IConfigurationSection options,
            IHttpClientFactory httpClientFactory,
            ILogger logger,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "BaselinkerConnector");

            ConfigureCompositionRoot(
                connectionString,
                clientId,
                options,
                httpClientFactory,
                moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            string clientId,
            IConfigurationSection options,
            IHttpClientFactory executionContextAccessor,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance(options);

            containerBuilder.RegisterModule(new LoggingModule(logger));

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterInstance(executionContextAccessor);

            containerBuilder.Register(ctx =>
            {
                var config = ctx.Resolve<IConfigurationSection>();
                var baselinkerOption = new BaselinkerOption();
                config.Bind(baselinkerOption);
                return Options.Create(baselinkerOption);
            }).As<IOptions<BaselinkerOption>>().SingleInstance();


            containerBuilder.Register(ctx =>
            {
                var httpClientFactory = ctx.Resolve<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(nameof(BaselinkerClient));
                var options = ctx.Resolve<IOptions<BaselinkerOption>>();
                return new BaselinkerClient(httpClient, options);
            }).As<IBaselinkerClient>();

            _container = containerBuilder.Build();

            BaselinkerConnectorCompositionRoot.SetContainer(_container);
        }
    }
}
