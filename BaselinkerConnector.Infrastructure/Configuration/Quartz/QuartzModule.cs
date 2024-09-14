using Autofac;
using Autofac.Extras.Quartz;

namespace BaselinkerConnector.Infrastructure.Configuration.Quartz
{
    public class QuartzModule : Module
    {
        protected override void Load(ContainerBuilder cb)
        {
            cb.RegisterModule(new QuartzAutofacFactoryModule());
            cb.RegisterModule(new QuartzAutofacJobsModule(typeof(QuartzStartup).Assembly));
        }
    }
}
