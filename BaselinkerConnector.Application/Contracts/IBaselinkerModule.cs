using AllegroConnector.Application.Contracts;
using MediatR;

namespace BaselinkerConnector.Application.Contracts
{
    public interface IBaselinkerModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);

        Task ExecuteRequestAsync(IRequest request);

        Task<TResult> ExecuteRequestAsync<TResult>(IRequest<TResult> request);
    }
}
