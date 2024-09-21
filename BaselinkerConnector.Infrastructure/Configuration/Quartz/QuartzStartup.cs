using Autofac;
using BaselinkerConnector.Infrastructure.Configuration.Processing.InternalCommands;
using BaselinkerConnector.Infrastructure.Configuration.Processing.Outbox;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Serilog;
using System.Collections.Specialized;

namespace BaselinkerConnector.Infrastructure.Configuration.Quartz
{
    internal class QuartzStartup
    {
        private static ILogger _logger;
        private static IScheduler scheduler;

        internal static void Initialize(ILogger logger, IContainer container)
        {
            _logger = logger
                    .ForContext("Module", "Baselinker")
                    .ForContext("Context", "Quartz");

            _logger.Information("Quartz starting...");

            var schedulerConfiguration = new NameValueCollection();
            schedulerConfiguration.Add("quartz.scheduler.instanceName", "Baselinker");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            scheduler.Start().GetAwaiter().GetResult();

            var processProductsJob = JobBuilder.Create<ProcessProductsJob>().Build();
            var processProductsTrigger = TriggerBuilder
                .Create()
                .StartNow()
                .WithCronSchedule("/15 * * ? * *")
                .Build();
            scheduler.ScheduleJob(processProductsJob, processProductsTrigger).GetAwaiter().GetResult();

            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();
            ITrigger triggerCommandsProcessing=
                    TriggerBuilder
                        .Create()
                        .StartNow()
                        .WithCronSchedule("0/2 * * ? * *")
                        .Build();
            
            scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();


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
