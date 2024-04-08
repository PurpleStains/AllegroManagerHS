using System.Globalization;

namespace AllegroConnector.Domain
{
    public class CsvGenericWriter
    {
        readonly string _productsCSV = "./AllegroAukcje/export.csv";
        readonly string _productsWithPricesCSV = "./AllegroCeny/Test_1_2024-03-11_21_53.csv";

        public List<AuctionWithPriceAndEan> Products()
        {
            var auctions = CsvGenericReader<Auction>.Read(_productsCSV).ToList();
            var products = CsvGenericReader<AuctionWithPrice>.Read(_productsWithPricesCSV).ToList();

            var result = CompactRelatedProducts(auctions, products);
            return result;
        }

        List<AuctionWithPriceAndEan> CompactRelatedProducts(List<Auction> auctions, List<AuctionWithPrice> products)
        {
            var result = new List<AuctionWithPriceAndEan>();
            foreach (var auction in auctions)
            {
                var relatedProduct = products.FirstOrDefault(x => x.products_ean.Equals(auction.products_ean));

                if (relatedProduct is null || string.IsNullOrEmpty(relatedProduct?.price))
                    continue;

                result.Add(new AuctionWithPriceAndEan()
                {
                    products_ean = auction.products_ean,
                    price = double.Parse(relatedProduct.price, CultureInfo.InvariantCulture),
                    auction_id = auction.auction_id
                });
            }

            return result;
        }
    }
}
