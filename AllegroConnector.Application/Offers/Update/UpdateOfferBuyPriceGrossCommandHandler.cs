using AllegroConnector.Application.Commands;

namespace AllegroConnector.Application.Offers.Update
{
    internal class UpdateOfferBuyPriceGrossCommandHandler : ICommandHandler<UpdateOfferBuyPriceGrossCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateOfferBuyPriceGrossCommand request, CancellationToken cancellationToken)
        {
            ;
            return  Guid.NewGuid();
        }
    }
}
