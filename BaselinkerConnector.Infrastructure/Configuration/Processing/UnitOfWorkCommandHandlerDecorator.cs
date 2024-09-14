using AllegroConnector.BuildingBlocks.Infrastructure;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T>(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            BaselinkerContext baselinkerContext) 
        : ICommandHandler<T>
        where T : ICommand
    {
        public async Task Handle(T command, CancellationToken cancellationToken)
        {
            await decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase)
            {
                var internalCommand =
                    await baselinkerContext.InternalCommands.FirstOrDefaultAsync(
                        x => x.Id == command.Id,
                        cancellationToken: cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
