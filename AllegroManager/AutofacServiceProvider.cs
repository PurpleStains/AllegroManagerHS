using AllegroManager.Modules.Allegro;
using Autofac;

namespace AllegroManager
{
    public class AutofacServiceProvider : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AllegroManagerAutoFacModule());
        }
    }
}
