using AllegroConnector.Application.AllegroApi;
using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroOAuth;
using AllegroConnector.BuildingBlocks.Application;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Infrastructure.Configuration.DataAccess;
using AllegroConnector.Infrastructure.Configuration.HttpClient;
using AllegroConnector.Infrastructure.Configuration.Logging;
using AllegroConnector.Infrastructure.Configuration.Mapper;
using AllegroConnector.Infrastructure.Configuration.Mediation;
using AllegroConnector.Infrastructure.Domain.AllegroOAuthToken;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net.Http;

namespace AllegroConnector.Infrastructure.Configuration
{
    public class AllegroConnectorStartup
    {
        static IContainer _container;
        public static void Initialize(
            string connectionString,
            IHttpClientFactory executionContextAccessor,
            ILogger logger,
            //IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "AllegroConnector");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                moduleLogger);
        }

        public static void Stop()
        {
           //quartz stop
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IHttpClientFactory executionContextAccessor,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "AllegroConnector")));

            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            //containerBuilder.RegisterModule(new ProcessingModule());
            //containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new AllegroClientModule());
            //containerBuilder.RegisterModule(new AuthenticationModule());

            //var domainNotificationsMap = new BiDictionary<string, Type>();

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
