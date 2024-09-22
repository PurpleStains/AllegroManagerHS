using AllegroConnector.Infrastructure.Configuration.Processing.Inbox;
using AllegroConnector.Infrastructure.Configuration.Processing.InternalCommands;
using AllegroConnector.Infrastructure.Configuration.Processing.Outbox;
using Autofac;
using Quartz;
using Quartz.Impl;
using Serilog;
using System.Collections.Specialized;

namespace AllegroConnector.Infrastructure.Configuration.Quartz
{
    internal class QuartzStartup
    {
        private static ILogger _logger;
        private static IScheduler scheduler;
        internal static void Initialize(ILogger logger, IContainer container)
        {
            _logger = logger
                    .ForContext("Module", "Allegro")
                    .ForContext("Context", "Quartz");

            _logger.Information("Quartz starting...");

            var schedulerConfiguration = new NameValueCollection();
            schedulerConfiguration.Add("quartz.scheduler.instanceName", "Allegro");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            scheduler.Start().GetAwaiter().GetResult();

            var processOffersJob = JobBuilder.Create<ProcessOffersJob>().Build();
            var processOffersTrigger = TriggerBuilder
                .Create()
                .StartNow()
                .WithCronSchedule("0 0 * ? * *")
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

            var processInboxJob = JobBuilder.Create<ProcessInboxJob>().Build();
            var processInboxTrigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();

            scheduler
                .ScheduleJob(processInboxJob, processInboxTrigger)
                .GetAwaiter().GetResult();


            var processOutboxJob = JobBuilder.Create<ProcessOutboxJob>().Build();
            ITrigger trigger;
            trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();
            scheduler.ScheduleJob(processOutboxJob, trigger).GetAwaiter().GetResult();

            _logger.Information("Quartz started.");
        }
    }
}
