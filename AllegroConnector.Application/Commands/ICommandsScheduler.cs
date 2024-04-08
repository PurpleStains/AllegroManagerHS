using AllegroConnector.Application.Contracts;

namespace AllegroConnector.Application.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}