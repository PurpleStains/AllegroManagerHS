using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.Offer;
using AllegroConnector.Domain.Requests;
using AllegroConnector.Domain.Responses;
using System.Globalization;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class CalculateOfferFeeQueryHandler(IAllegroApiService apiClient,
        IAllegroOffersRepository offersRepository,
        IFeeCalculator<FeeCalculationBasis, FeeDetails> calculator)
        : IQueryHandler<CalculateOfferFeeQuery, OffersFeeResponse>
    {
        public async Task<OffersFeeResponse> Handle(CalculateOfferFeeQuery query, CancellationToken cancellationToken)
        {
            var csvReader = new CsvGenericWriter();
            var product = csvReader.Products().Find(x => x.auction_id.Equals(query.OfferId));
            var fromAllegro = await apiClient.GetOffers(product.auction_id);
            var offer = await offersRepository.GetByIdAsync(product.auction_id);
            var request = new CalculateFeeRequest()
            {
                offer = fromAllegro
            };
           
            var response = await apiClient.CalculateOfferFee(request);

            var calculationBasis = new FeeCalculationBasis()
            {
                AuctionBuyPriceGross = offer.PriceGross,
                BuyPriceGross = product.price,
                AllegroFee = double.Parse(response.commissions.FirstOrDefault()?.fee.amount, CultureInfo.InvariantCulture)
            };

            var calculated = calculator.Calculate(calculationBasis);

            var afterFee = new OfferCalculations()
            {
                ProductEAN = product.products_ean,
                AuctionId = product.auction_id,
                OfferName = offer.Name,
                ProductImage = fromAllegro.images.FirstOrDefault(),
                FeeDetails = calculated
            };
            return new OffersFeeResponse() { Calculations = new List<OfferCalculations>{ afterFee } };
        }
    }
}
