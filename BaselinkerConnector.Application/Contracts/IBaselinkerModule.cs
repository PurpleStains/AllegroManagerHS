using AllegroConnector.Application.Contracts;

namespace BaselinkerConnector.Application.Contracts
{
    public interface IBaselinkerModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
