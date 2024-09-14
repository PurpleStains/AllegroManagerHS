using MediatR;

namespace BaselinkerConnector.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
