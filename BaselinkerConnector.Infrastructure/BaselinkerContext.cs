using AllegroConnector.BuildingBlocks.Infrastructure.InternalCommands;
using BaselinkerConnector.Domain.Products;
using BaselinkerConnector.Infrastructure.Domain.Products;
using BaselinkerConnector.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;

namespace BaselinkerConnector.Infrastructure
{
    public class BaselinkerContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public BaselinkerContext(DbContextOptions<BaselinkerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaselinkerProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
