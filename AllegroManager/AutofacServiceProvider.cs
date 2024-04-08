using AllegroConnector.Infrastructure;
using AllegroManager.Modules.Allegro;
using Autofac;
using ILogger = Serilog.ILogger;

namespace AllegroManager
{
    public class AutofacServiceProvider : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AllegroManagerAutoFacModule());

            //AllegroConnectorStartup.Initialize(_connectionString, _logger);
        }
    }
}
