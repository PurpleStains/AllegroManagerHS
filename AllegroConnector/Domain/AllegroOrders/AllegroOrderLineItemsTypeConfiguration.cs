using AllegroConnector.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllegroConnector.Infrastructure.Domain.AllegroOrders
{
    internal class AllegroOrderLineItemsTypeConfiguration : IEntityTypeConfiguration<OrderLineItem>
    {
        public void Configure(EntityTypeBuilder<OrderLineItem> builder)
        {
            builder.ToTable("OrderLineItems", "orders");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AllegroOffer)
                .WithMany(x => x.OrderLineItems);
        }
    }
}
