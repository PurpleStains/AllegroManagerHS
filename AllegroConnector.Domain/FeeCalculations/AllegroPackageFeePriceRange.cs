namespace AllegroConnector.Domain.FeeCalculations
{
    public struct AllegroPackageFeePriceRange
    {
        public AllegroPackageFeePriceRange(double startRange, double endRange)
        {
            StartRange = startRange;
            EndRange = endRange;
        }

        public double StartRange { get; set; }
        public double EndRange { get; set; }
    }
}
