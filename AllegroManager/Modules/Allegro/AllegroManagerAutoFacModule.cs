using AllegroConnector.Application.Contracts;
using AllegroConnector.Infrastructure;
using Autofac;

namespace AllegroManager.Modules.Allegro
{
    public class AllegroManagerAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AllegroModule>()
                .As<IAllegroModule>()
                .InstancePerLifetimeScope();
        }
    }
}
