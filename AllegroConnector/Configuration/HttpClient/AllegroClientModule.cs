﻿using AllegroConnector.Application.AllegroApi;
using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroOAuth;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Infrastructure.Domain.AllegroOAuthToken;
using Autofac;

namespace AllegroConnector.Infrastructure.Configuration.HttpClient
{
    internal class AllegroClientModule(string clientId) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AllegroOAuthTokenHandler>()
                .As<IAllegroOAuthTokenHandler>()
                .SingleInstance();

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
                return new AllegroApiService(httpClient, tokenHandler);
            }).As<IAllegroApiService>();
        }
    }
}
