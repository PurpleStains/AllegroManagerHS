using AllegroConnector.BuildingBlocks.Infrastructure;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing
{
    public class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult>
        (
            ICommandHandler<T, TResult> decorated,
            IUnitOfWork unitOfWork,
            BaselinkerContext baselinkerContext
        )
        : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase<TResult>)
            {
                var internalCommand = await baselinkerContext.InternalCommands
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