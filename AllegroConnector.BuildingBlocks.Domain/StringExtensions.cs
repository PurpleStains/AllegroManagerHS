using System.Globalization;

namespace AllegroConnector.BuildingBlocks.Domain
{
    public static class StringExtensions
    {
        public static double ToDouble(this string input){
            return double.Parse(input, CultureInfo.InvariantCulture);
        }
    }
}
