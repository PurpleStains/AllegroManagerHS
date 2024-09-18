using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.Responses;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class OfferQueryHandler : IQueryHandler<OfferQuery, ConcreteProductOfferResponse>
    {
        readonly IAllegroApiService _apiClinet;

        public OfferQueryHandler(IAllegroApiService apiClinet)
        {
            _apiClinet = apiClinet;
        }

        public async Task<ConcreteProductOfferResponse> Handle(OfferQuery request, CancellationToken cancellationToken)
        {
            var result = await _apiClinet.GetOfferDetails(request.OfferId);

            return result;
        }
    }
}
