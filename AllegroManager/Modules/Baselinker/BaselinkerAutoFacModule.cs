using AllegroConnector.Application.Contracts;
using Autofac;
using BaselinkerConnector.Application.Contracts;
using BaselinkerConnector.Infrastructure;

namespace AllegroManager.Modules.Baselinker
{
    public class BaselinkerAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaselinkerModule>()
                .As<IBaselinkerModule>()
                .InstancePerLifetimeScope();
        }
    }
}
