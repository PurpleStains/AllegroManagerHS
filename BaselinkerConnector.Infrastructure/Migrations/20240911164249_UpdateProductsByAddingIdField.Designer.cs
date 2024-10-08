﻿// <auto-generated />
using BaselinkerConnector.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaselinkerConnector.Infrastructure.Migrations
{
    [DbContext(typeof(BaselinkerContext))]
    [Migration("20240911164249_UpdateProductsByAddingIdField")]
    partial class UpdateProductsByAddingIdField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaselinkerConnector.Domain.Products.Product", b =>
                {
                    b.Property<double>("AverageGrossPriceBuy")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<double>("AveragePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<string>("Ean")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.ToTable("Product", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
