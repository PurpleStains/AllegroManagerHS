using AllegroConnector.BuildingBlocks.Application.Pipelines.Http;
using MediatR;

namespace AllegroConnector.Application.Contracts
{
    public abstract class HttpCallRequestBase : IRequest, IHttpCall
    {
    }

    public abstract class HttpCallRequestBase<TResult> : IRequest<TResult>, IHttpCall
    {
    }
}
