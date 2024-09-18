using AllegroConnector.Application.Offers.ProcessOffers;
using AllegroConnector.Infrastructure.Configuration.Processing;
using Quartz;

namespace AllegroConnector.Infrastructure.Configuration.Quartz
{
    [DisallowConcurrentExecution]
    public class ProcessOffersJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandsExecutor.Execute(new ProcessOffersCommand());
        }
    }
}
