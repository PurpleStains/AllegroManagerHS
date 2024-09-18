using AllegroConnector.Application.Commands;
using AllegroConnector.Domain;
using AllegroConnector.Domain.EAN;
using AllegroConnector.Domain.Offer;
using Serilog;

namespace AllegroConnector.Application.Offers.Create
{
    public class CreateOfferCommandHandler(
        IAllegroApiService api,
        IAllegroOffersRepository repository,
        IEANValidator eanValidator)
        : ICommandHandler<CreateOfferCommand>
    {
        private readonly ILogger logger = Log.ForContext<CreateOfferCommandHandler>();
        public async Task Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            if (await repository.GetByIdAsync(request.OfferId) is not null)
            {
                return;
            }

            var response = await api.GetOfferDetails(request.OfferId);

            var ean = response.productSet[0].product.parameters
                .Where(x => x.values.Any(v => eanValidator.IsValidEAN(v)))
                .FirstOrDefault(x => x.values.Any(value => eanValidator.IsValidEAN(value)))
                .values.FirstOrDefault();

            if (ean == null)
            {
                logger.Error($"Missing EAN for offer {request.OfferId}");
                return;
            }

            var offer = AllegroOffer.Create(
                Guid.NewGuid(),
                request.OfferId,
                response.category.id,
                ean,
                response.name,
                response.stock.available,
                response.publication.status,
                response.sellingMode?.price?.amount);

            await repository.AddAsync(offer);
        }
    }
}
