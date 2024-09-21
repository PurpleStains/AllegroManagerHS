using Autofac;
using Autofac.Extras.Quartz;
using Quartz;

namespace BaselinkerConnector.Infrastructure.Configuration.Quartz
{
    public class QuartzModule : Module
    {
        protected override void Load(ContainerBuilder cb)
        {
            cb.RegisterModule(new QuartzAutofacFactoryModule());
            cb.RegisterModule(new QuartzAutofacJobsModule(typeof(ProcessProductsJob).Assembly));
        }
    }
}
