using AllegroConnector.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllegroConnector.Infrastructure.Domain.AllegroOrders
{
    internal class AllegroOrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "orders");

            builder.HasKey(x => x.Id);
        }
    }
}
