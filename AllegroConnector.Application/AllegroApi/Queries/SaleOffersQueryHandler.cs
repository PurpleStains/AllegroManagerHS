using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Offer;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class SaleOffersQueryHandler : IQueryHandler<SaleOffersQuery, SaleOffersResponse>
    {
        readonly IAllegroApiClient _apiClient;
        readonly IAllegroOffersRepository _offersRepository;

        public SaleOffersQueryHandler(IAllegroApiClient allegroApiClient, IAllegroOffersRepository offersRepository)
        {
            _apiClient = allegroApiClient;
            _offersRepository = offersRepository;
        }

        public async Task<SaleOffersResponse> Handle(SaleOffersQuery query, CancellationToken cancellationToken)
        {
            var result = await _apiClient.SaleOffers(query.Limit, query.Offset);
            var offers = await _offersRepository.Get();
            foreach (var offer in result.offers)
            {
                var allegroOffer = AllegroOffer.Create(
                    Guid.NewGuid(),
                    offer.id,
                    offer.category.id,
                    offer.name,
                    offer.stock.available,
                    offer.publication.status,
                    offer.sellingMode?.price?.amount);

                if (offers.Any(x => x.OfferId.Equals(offer.id)))
                    continue;

                await _offersRepository.AddAsync(allegroOffer);
            }

            await _offersRepository.CommitAsync();
            return result;
        }
    }
}
