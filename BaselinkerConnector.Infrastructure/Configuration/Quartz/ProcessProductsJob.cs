using BaselinkerConnector.Application.Products.Commands;
using BaselinkerConnector.Infrastructure.Configuration.Processing;
using Quartz;

namespace BaselinkerConnector.Infrastructure.Configuration.Quartz
{
    [DisallowConcurrentExecution]
    public class ProcessProductsJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandsExecutor.Execute(new ProcessProductsCommand());
        }
    }
}
