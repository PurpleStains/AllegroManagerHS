namespace AllegroConnector.Domain.FeeCalculations
{
    public class AllegroPackageFee : IAllegroPackageFee
    {
        private readonly Dictionary<AllegroPackageFeePriceRange, double> _fees =  new()
            {
                { new AllegroPackageFeePriceRange(0, 49.99) , 1.59},
                { new AllegroPackageFeePriceRange(50, 59.99) , 2.09},
                { new AllegroPackageFeePriceRange(60, 79.99) , 2.89},
                { new AllegroPackageFeePriceRange(80, 119.99) , 3.99},
                { new AllegroPackageFeePriceRange(120, 199.99) , 6.69},
                { new AllegroPackageFeePriceRange(200, double.PositiveInfinity) , 8.69}
            };

        public double Fee(double toCompare)
        {
            return _fees.First(x => 
            x.Key.StartRange <= toCompare &&
            x.Key.EndRange >= toCompare).Value;
        }
    }
}
