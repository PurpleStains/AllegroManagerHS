using BaselinkerConnector.Infrastructure.Configuration.Processing;
using BaselinkerConnector.Infrastructure.Configuration.Processing.Outbox;
using Quartz;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Configuration.Processing.Outbox
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandsExecutor.Execute(new ProcessOutboxCommand());
        }
    }
}