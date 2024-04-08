using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.Responses;
using System.Globalization;

namespace AllegroConnector.Application.AllegroApi.Queries
{
    internal class CalculateOfferFeeQueryHandler(IAllegroApiClient apiClient, IFeeCalculator<FeeCalculationBasis, FeeDetails> calculator) 
        : IQueryHandler<CalculateOfferFeeQuery, OffersFeeResponse>
    {
        public async Task<OffersFeeResponse> Handle(CalculateOfferFeeQuery query, CancellationToken cancellationToken)
        {
            var csvReader = new CsvGenericWriter();
            var result = csvReader.Products();

            var responses = new List<OfferCalculations>();
            foreach(var product in result)
            {
                var response = await apiClient.CalculateOfferFee(product.auction_id);
                var offer = await apiClient.GetOffers(product.auction_id);

                var calculationBasis = new FeeCalculationBasis()
                {
                    AuctionBuyPriceGross = offer.sellingMode.price.amount,
                    BuyPriceGross = product.price,
                    AllegroFee = double.Parse(response.commissions.FirstOrDefault()?.fee.amount, CultureInfo.InvariantCulture)
                };

                var calculated = calculator.Calculate(calculationBasis);

                var afterFee = new OfferCalculations()
                {
                    ProductEAN = product.products_ean,
                    AuctionId = product.auction_id,
                    OfferName = offer.name,
                    FeeDetails = calculated
                };
                responses.Add(afterFee);
            }
            return new OffersFeeResponse() { Calculations = responses};
        }
    }
}
