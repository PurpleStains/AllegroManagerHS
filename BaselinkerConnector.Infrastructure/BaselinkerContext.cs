using BaselinkerConnector.Domain.Products;
using BaselinkerConnector.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaselinkerConnector.Infrastructure
{
    public class BaselinkerContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public BaselinkerContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaselinkerProductEntityTypeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
