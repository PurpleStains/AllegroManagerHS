﻿using AllegroConnector.Application.AllegroApi;
using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroOAuth;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Infrastructure.Domain.AllegroOAuthToken;
using Autofac;

namespace AllegroConnector.Infrastructure.Configuration.HttpClient
{
    internal class AllegroClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
            {
                var httpClientFactory = ctx.Resolve<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(nameof(AllegroOAuthService)); // Use the named client
                return new AllegroOAuthService(httpClient);
            }).As<IAllegroOAuthService>();
            //builder.RegisterType<AllegroOAuthService>().As<IAllegroOAuthService>();
            builder.RegisterType<AllegroApiClient>().AsSelf();
            builder.RegisterType<AllegroOAuthTokenHandler>()
                .As<IAllegroOAuthTokenHandler>()
                .SingleInstance();

            builder.RegisterType<AllegroPackageFee>()
                .As<IAllegroPackageFee>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FeeCalculator>()
                .As<IFeeCalculator<FeeCalculationBasis, FeeDetails>>()
                .InstancePerLifetimeScope();
        }
    }
}