using AllegroConnector.Application.Queries;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.Offer;
using AllegroConnector.Domain.Requests;
using AllegroConnector.Domain.Responses;
using System.Globalization;
using Offer = AllegroConnector.Domain.Requests.Offer;

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
            var offer = offersRepository.GetByIdAsync(product.auction_id).Result;
            var request = new CalculateFeeRequest()
            {
                offer = new Offer()
                {
                    id = offer.OfferId,
                    category = new()
                    {
                        id = offer.CategoryId,
                    },
                    sellingMode = new() 
                    { 
                        format ="BUY_NOW",
                        price = new()
                        {
                            amount = offer.PriceGross,
                            currency = "PLN"
                        }
                    }
                },
                classifiedsPackages = null
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
                FeeDetails = calculated
            };
            return new OffersFeeResponse() { Calculations = new List<OfferCalculations>{ afterFee } };
        }
    }
}
