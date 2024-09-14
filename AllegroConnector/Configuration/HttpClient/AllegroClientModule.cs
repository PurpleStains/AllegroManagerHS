using AllegroConnector.Application.AllegroApi;
using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroOAuth;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Infrastructure.Domain.AllegroOAuthToken;
using Autofac;
using System.Net.Http.Headers;

namespace AllegroConnector.Infrastructure.Configuration.HttpClient
{
    internal class AllegroClientModule(string clientId) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AllegroOAuthTokenRepository>()
                .As<IOAuthTokenRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AllegroOAuthTokenHandler>()
                .As<IAllegroOAuthTokenHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AllegroPackageFee>()
                .As<IAllegroPackageFee>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FeeCalculator>()
                .As<IFeeCalculator<FeeCalculationBasis, FeeDetails>>()
                .InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var httpClientFactory = ctx.Resolve<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(nameof(AllegroOAuthService));
                return new AllegroOAuthService(httpClient, clientId);
            }).As<IAllegroOAuthService>();

            builder.Register(ctx =>
            {
                var tokenHandler = ctx.Resolve<IAllegroOAuthTokenHandler>();
                var httpClientFactory = ctx.Resolve<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(nameof(AllegroApiService));
                httpClient.BaseAddress = new Uri("https://api.allegro.pl/");
                httpClient.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", tokenHandler.GetToken().Result);

                return new AllegroApiService(httpClient, tokenHandler);
            }).As<IAllegroApiService>()
            .InstancePerLifetimeScope();
        }
    }
}
