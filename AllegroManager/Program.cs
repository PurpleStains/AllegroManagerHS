using AllegroConnector.Application.AllegroOAuth;
using AllegroConnector.Infrastructure;
using AllegroConnector.Infrastructure.Configuration;
using AllegroManager.Modules.Allegro;
using AllegroManager.Modules.Baselinker;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BaselinkerConnector.Infrastructure;
using BaselinkerConnector.Infrastructure.Configuration;
using Keycloak.AuthServices.Authentication;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

Serilog.ILogger _logger = ConfigureLogger();
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var clientId = builder.Configuration["AllegroApi:ClientId"];
var clientSecret = builder.Configuration["AllegroApi:ClientSecret"];
var baselinkerConfig = builder.Configuration.GetSection("Baselinker");

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    builder.RegisterModule(new AllegroManagerAutoFacModule()));

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    builder.RegisterModule(new BaselinkerAutoFacModule()));


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AllegroContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<BaselinkerContext>(options => options.UseSqlServer(connectionString));
ConfigureHttpClients(builder.Services);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3001")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
        });
});

builder.Services.AddAuthorization();
builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);

var app = builder.Build();
var container = app.Services.GetAutofacRoot();
InitializeModules(container);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseCors("MyPolicy");
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

Serilog.ILogger ConfigureLogger()
{
    var logger = new LoggerConfiguration()
        //.Enrich.FromLogContext()
        .WriteTo.Console(
            outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.File("logs/logs")
        .CreateLogger();
    return logger;
}

void InitializeModules(ILifetimeScope services)
{
    var httpClientFactory = services.Resolve<IHttpClientFactory>();
    AllegroConnectorStartup.Initialize(connectionString, clientId, httpClientFactory, _logger, null);
    BaselinkerConnectorStartup.Initialize(connectionString, clientId, baselinkerConfig, httpClientFactory, _logger, null);
}

void ConfigureHttpClients(IServiceCollection services)
{
    services.AddHttpClient<AllegroOAuthService>((serviceProvider, httpClient) =>
    {
        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        httpClient.BaseAddress = new Uri("https://allegro.pl/auth/oauth/");
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5),
        };
    })
    .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

    //services.AddHttpClient<AllegroApiService>((serviceProvider, httpClient) =>
    //{
    //    httpClient.BaseAddress = new Uri("https://api.allegro.pl/");
    //})
    //.ConfigurePrimaryHttpMessageHandler(() =>
    //{
    //    return new SocketsHttpHandler
    //    {
    //        PooledConnectionLifetime = TimeSpan.FromMinutes(5),
    //    };
    //})
    //.SetHandlerLifetime(Timeout.InfiniteTimeSpan);
}