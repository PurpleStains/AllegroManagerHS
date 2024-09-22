using AllegroConnector.BuildingBlocks.Domain;

namespace AllegroConnector.Domain.FeeCalculations
{
    public class FeeCalculator : IFeeCalculator<FeeCalculationBasis, FeeDetails>
    {
        private readonly IAllegroPackageFee _allegroPackageFee;

        public FeeCalculator(IAllegroPackageFee allegroPackageFee)
        {
            _allegroPackageFee = allegroPackageFee;
        }
        public FeeDetails Calculate(FeeCalculationBasis calculation)
        {
            var allegroBuyPriceGross = calculation.AuctionBuyPriceGross.ToDouble();
            var packageFee = _allegroPackageFee.Fee(allegroBuyPriceGross);
            var fee = calculation.AllegroFee + packageFee;
            var income = allegroBuyPriceGross
                - calculation.BuyPriceGross
                - fee;

            var margin = income / calculation.AuctionBuyPriceGross.ToDouble() * 100;

            return new FeeDetails
            {
                AuctionPrice = calculation.AuctionBuyPriceGross,
                BuyPrice = calculation.BuyPriceGross,
                BasisFee = calculation.AllegroFee,
                PackageFee = packageFee,
                SummedFee = fee,
                Income = income,
                Margin = margin
            };
        }
       
    }
}
