using AllegroConnector.Application.Commands;
using AllegroConnector.Domain.Offer;

namespace AllegroConnector.Application.Offers.UpdateBuyPrice
{
    internal class UpdateOfferBuyPriceGrossCommandHandler(
        IAllegroOffersRepository repository)
        : ICommandHandler<UpdateOfferBuyPriceGrossCommand>
    {
        public async Task Handle(UpdateOfferBuyPriceGrossCommand request, CancellationToken cancellationToken)
        {
            var offer = await repository.GetByEanAsync(request.ProductEan);
            if (offer is null) return;

            offer.UpdateBuyPriceGross(request.BuyPrice);
        }
    }
}
