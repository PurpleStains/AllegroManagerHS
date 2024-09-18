using AllegroConnector.Infrastructure.Configuration.Processing.InternalCommands;
using Autofac;
using Quartz;
using Serilog;

namespace AllegroConnector.Infrastructure.Configuration.Quartz
{
    internal class QuartzStartup
    {
        private static ILogger _logger;
        internal static void Initialize(ILogger logger, IContainer container)
        {
            _logger = logger
                    .ForContext("Module", "Allegro")
                    .ForContext("Context", "Quartz");

            _logger.Information("Quartz starting...");

            var scheduler = container.Resolve<IScheduler>();
            scheduler.Start().GetAwaiter().GetResult();

            var processOffersJob = JobBuilder.Create<ProcessOffersJob>().Build();
            var processOffersTrigger = TriggerBuilder
                .Create()
                .StartNow()
                .WithCronSchedule("5 * * ? * *")
                .Build();

            scheduler.ScheduleJob(processOffersJob, processOffersTrigger);

            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();

            ITrigger triggerCommandsProcessing =
                    TriggerBuilder
                        .Create()
                        .StartNow()
                        .WithCronSchedule("0/2 * * ? * *")
                        .Build();


            scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();

            _logger.Information("Quartz started.");
        }
    }
}
