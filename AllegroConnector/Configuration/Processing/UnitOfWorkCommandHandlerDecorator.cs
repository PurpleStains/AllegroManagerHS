using AllegroConnector.Application.Commands;
using AllegroConnector.Application.Contracts;
using AllegroConnector.BuildingBlocks.Infrastructure;
using AllegroConnector.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AllegroConnector.Infrastructure.Configuration.Processing
{
    public class UnitOfWorkCommandHandlerDecorator<T>
        : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> decorated;
        private readonly IUnitOfWork unitOfWork;
        private readonly AllegroContext allegroContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            AllegroContext context)
        {
            this.decorated = decorated;
            this.unitOfWork = unitOfWork;
            allegroContext = context;
        }

        public async Task Handle(T command, CancellationToken cancellationToken)
        {
            await decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase)
            {
                var internalCommand =
                    await allegroContext.InternalCommands.FirstOrDefaultAsync(
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
