using AllegroConnector.BuildingBlocks.Application.Pipelines.Http;
using MediatR;

namespace BaselinkerConnector.Infrastructure.Configuration.Pipelines
{
    public class BaselinkerClientPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IHttpCall
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return await next();
        }
    }
}
