using AllegroConnector.Application.Contracts;
using AllegroConnector.Infrastructure.Configuration;
using AllegroConnector.Infrastructure.Configuration.Processing;
using Autofac;
using MediatR;

namespace AllegroConnector.Infrastructure
{
    public class AllegroModule : IAllegroModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = AllegroConnectorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
