using AllegroConnector.Domain.FeeCalculations;

namespace AllegroManager.AllegroConnectorTests
{
    [TestFixture]
    public class PackageFeeCalculationTest
    {
        private AllegroPackageFee _service = new AllegroPackageFee();

        [TestCase(1d, 1.59d)]
        [TestCase(51d, 2.09d)]
        [TestCase(61d, 2.89d)]
        [TestCase(81d, 3.99d)]
        [TestCase(121d, 6.69d)]
        [TestCase(200, 8.69d)]
        public void Test2(double input, double expected)
        {
            var calculation = _service.Fee(input);

            Assert.That(calculation, Is.EqualTo(expected));
        }
    }
}