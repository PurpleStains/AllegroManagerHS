using BaselinkerConnector.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace BaselinkerConnector.Infrastructure.Domain.Products
{
    public class ProductsRepository(BaselinkerContext context) : IProductsRepository
    {
        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
