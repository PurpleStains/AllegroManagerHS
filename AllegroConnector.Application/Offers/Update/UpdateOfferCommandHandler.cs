using AllegroConnector.Application.Commands;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Offer;

namespace AllegroConnector.Application.Offers.Update
{
    internal class UpdateOfferCommandHandler(
        IAllegroApiService allegroApiService,
        IAllegroOffersRepository repository) : ICommandHandler<UpdateOfferCommand>
    {
        public async Task Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await repository.GetByIdAsync(request.OfferId);
            if (offer == null) return;

            var offerDetails = await allegroApiService.GetOfferDetails(offer.OfferId);

            offer.UpdatePriceGross(offerDetails.sellingMode?.price?.amount);
        }
    }
}
