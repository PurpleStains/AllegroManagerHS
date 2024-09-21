namespace BaselinkerConnector.Domain.Products
{
    public interface IProductsRepository
    {
        Task AddAsync(Product product);

        Task<int> Commit();

        Task<Product?> GetByIdAsync(int id);

        Task<Product?> GetByIdAsync(Guid id);
    }
}
