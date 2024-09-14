using BaselinkerConnector.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaselinkerConnector.Infrastructure.Domain.Products
{
    internal class BaselinkerProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductId)
                   .IsRequired();

            builder.Property(p => p.Ean)
                   .HasMaxLength(13)
                   .IsRequired();

            builder.Property(p => p.Sku)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(p => p.Stock);

            builder.Property(p => p.AveragePrice)
                   .HasPrecision(18, 2);

            builder.Property(p => p.AverageGrossPriceBuy)
                   .HasPrecision(18, 2);
        }
    }
}
