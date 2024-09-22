using AllegroConnector.Application.Commands;
using AllegroConnector.Domain;
using AllegroConnector.Domain.FeeCalculations;
using AllegroConnector.Domain.Offer;
using AllegroConnector.Domain.Requests;
using System.Globalization;

namespace AllegroConnector.Application.Offers.UpdateAllegroFee
{
    internal class UpdateAllegroFeeOnStoredOfferCommandHandler(
        IAllegroOffersRepository repository,
        IFeeCalculator<FeeCalculationBasis, FeeDetails> calculator,
        IAllegroApiService allegroApi)
        : ICommandHandler<UpdateAllegroFeeOnStoredOfferCommand>
    {
        public async Task Handle(UpdateAllegroFeeOnStoredOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await repository.GetByIdAsync(request.OfferId);
            if (offer == null) return;

            var fromAllegro = await allegroApi.GetOfferDetails(offer.OfferId);
            var requestMessage = new CalculateFeeRequest()
            {
                offer = fromAllegro
            };

            var response = await allegroApi.CalculateOfferFee(requestMessage);
            if (response == null) return;


            var allegroFee = double.Parse(response.commissions.FirstOrDefault()?.fee.amount, CultureInfo.InvariantCulture);
            var calculationBasis = new FeeCalculationBasis()
            {
                AuctionBuyPriceGross = offer.PriceGross!,
                BuyPriceGross = offer.BuyPriceGross,
                AllegroFee = allegroFee
            };

            var calculated = calculator.Calculate(calculationBasis);
            var afterFee = new OfferCalculations()
            {
                ProductEAN = offer.EAN,
                AuctionId = offer.OfferId,
                OfferName = offer.Name,
                ProductImage = fromAllegro.images.FirstOrDefault(),
                FeeDetails = calculated
            };

            offer.UpdateAllegroFee(afterFee.FeeDetails.SummedFee);
            offer.UpdateMargin(afterFee.FeeDetails.Margin);
            offer.UpdatePackageFee(afterFee.FeeDetails.PackageFee);
            offer.UpdateIncome(afterFee.FeeDetails.Income);
        }
    }
}
