using AllegroConnector.BuildingBlocks.Infrastructure.InternalCommands;
using AllegroConnector.Domain.OAuthToken;
using AllegroConnector.Domain.Offer;
using AllegroConnector.Domain.Orders;
using AllegroConnector.Infrastructure.Domain.AllegroOffers;
using AllegroConnector.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;

namespace AllegroConnector.Infrastructure
{
    public class AllegroContext : DbContext
    {
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<AllegroOAuthToken> AllegroOAuthTokens { get; set; }
        public DbSet<AllegroOffer> AllegroOffers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        public AllegroContext(DbContextOptions<AllegroContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AllegroOfferEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); 
        }
    }
}
