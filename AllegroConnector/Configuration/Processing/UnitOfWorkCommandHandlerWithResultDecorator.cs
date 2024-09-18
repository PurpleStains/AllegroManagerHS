using AllegroConnector.Application.Commands;
using AllegroConnector.Application.Contracts;
using AllegroConnector.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AllegroConnector.Infrastructure.Configuration.Processing
{
    public class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult>
        (
            ICommandHandler<T, TResult> decorated,
            IUnitOfWork unitOfWork,
            AllegroContext allegroContext
        )
        : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await decorated.Handle(command, cancellationToken);

            if (command is AllegroConnector.Configuration.InternalCommandBase<TResult>)
            {
                var internalCommand = await allegroContext.InternalCommands
                    .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}