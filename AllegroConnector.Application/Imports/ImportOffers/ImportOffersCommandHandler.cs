using AllegroConnector.Application.Commands;
using AllegroConnector.Application.Offers.Create;
using FluentResults;

namespace AllegroConnector.Application.Imports.ImportOffers
{
    public class ImportOffersCommandHandler(ICommandsScheduler scheduler) : ICommandHandler<ImportOffersCommand, Result>
    {
        public async Task<Result> Handle(ImportOffersCommand request, CancellationToken cancellationToken)
        {

            foreach(var offerId in request.PlainOffers)
            {
                await scheduler.EnqueueAsync(new CreateOfferCommand(Guid.NewGuid(), offerId));
            }

            return Result.Ok();
        }
    }
}
