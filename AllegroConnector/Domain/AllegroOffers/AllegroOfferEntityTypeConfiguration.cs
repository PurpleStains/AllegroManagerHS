﻿using AllegroConnector.Domain.Offer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllegroConnector.Infrastructure.Domain.AllegroOffers
{
    internal class AllegroOfferEntityTypeConfiguration : IEntityTypeConfiguration<AllegroOffer>
    {
        public void Configure(EntityTypeBuilder<AllegroOffer> builder)
        {
            builder.ToTable("AllegroOffers", "offers");
            builder.HasKey(x => x.AllegroOfferId);

            builder.Property<string>("OfferId").HasColumnName("OfferId");
            builder.Property<string>("CategoryId").HasColumnName("CategoryId");
            builder.Property(e => e.EAN).HasColumnName("EAN");
            builder.Property<string>("Name").HasColumnName("Name");
            builder.Property<int>("Stock").HasColumnName("Stock");
            builder.Property<string>("PriceGross").HasColumnName("PriceGross");
            builder.Property(x => x.BuyPriceGross).HasColumnName("BuyPriceGross");
            builder.Property(x => x.AllegroFee).HasColumnName("AllegroFee");
            builder.Property(x => x.Margin).HasColumnName("Margin");
            builder.Property(x => x.Income).HasColumnName("Income");
            builder.Property(x => x.PackageFee).HasColumnName("PackageFee");
        }
    }
}
