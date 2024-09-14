using Autofac;
using BaselinkerConnector.Application.Contracts;
using BaselinkerConnector.Infrastructure.Configuration;
using BaselinkerConnector.Infrastructure.Configuration.Processing;
using MediatR;

namespace BaselinkerConnector.Infrastructure
{
    public class BaselinkerModule : IBaselinkerModule
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
            using (var scope = BaselinkerConnectorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }

        public async Task<TResult> ExecuteRequestAsync<TResult>(IRequest<TResult> request)
        {
            return await RequestsExecutor.Execute(request);
        }

        public async Task ExecuteRequestAsync(IRequest request)
        {
            await RequestsExecutor.Execute(request);
        }
    }
}
