using AllegroConnector.BuildingBlocks.Infrastructure;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing
{
    public class UnitOfWorkCommandHandlerDecorator<T>
        : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> decorated;
        private readonly IUnitOfWork unitOfWork;
        private readonly BaselinkerContext baselinkerContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            BaselinkerContext context)
        {
            this.decorated = decorated;
            this.unitOfWork = unitOfWork;
            this.baselinkerContext = context;
        }

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
