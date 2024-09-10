using Autofac;
using MediatR;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing
{
    internal static class RequestsExecutor
    {
        internal static async Task Execute(IRequest command)
        {
            using (var scope = BaselinkerConnectorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        internal static async Task<TResult> Execute<TResult>(IRequest<TResult> command)
        {
            using (var scope = BaselinkerConnectorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
