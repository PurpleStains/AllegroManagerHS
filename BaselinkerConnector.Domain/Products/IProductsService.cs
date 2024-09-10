using FluentResults;

namespace BaselinkerConnector.Domain.Products
{
    public interface IProductsService
    {
        Task<Result> LoadProducts();
        Task UpdateProducts(IEnumerable<Product> products);
    }
}
