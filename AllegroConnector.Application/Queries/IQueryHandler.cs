using AllegroConnector.Application.Contracts;
using MediatR;

namespace AllegroConnector.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}
