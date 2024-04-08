using MediatR;

namespace AllegroConnector.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
