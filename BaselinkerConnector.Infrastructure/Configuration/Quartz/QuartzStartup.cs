using Autofac;
using BaselinkerConnector.Infrastructure.Configuration.Processing.InternalCommands;
using Quartz;
using Serilog;

namespace BaselinkerConnector.Infrastructure.Configuration.Quartz
{
    internal class QuartzStartup
    {
        private static ILogger _logger;
        internal static void Initialize(ILogger logger, IContainer container)
        {
            _logger = logger
                    .ForContext("Module", "Baselinker")
                    .ForContext("Context", "Quartz");

            _logger.Information("Quartz starting...");

            var scheduler = container.Resolve<IScheduler>();
            scheduler.Start().GetAwaiter().GetResult();

            var processProductsJob = JobBuilder.Create<ProcessProductsJob>().Build();
            var processProductsTrigger = TriggerBuilder
                .Create()
                .StartNow()
                .WithCronSchedule("/15 * * ? * *")
                .Build();

            scheduler. ScheduleJob(processProductsJob, processProductsTrigger);

            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();

            ITrigger triggerCommandsProcessing=
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
