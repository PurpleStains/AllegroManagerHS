using Autofac;
using MediatR;

namespace AllegroConnector.Infrastructure.Configuration.Processing
{
    internal static class RequestsExecutor
    {
        internal static async Task Execute(IRequest command)
        {
            using (var scope = AllegroConnectorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        internal static async Task<TResult> Execute<TResult>(IRequest<TResult> command)
        {
            using (var scope = AllegroConnectorCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
