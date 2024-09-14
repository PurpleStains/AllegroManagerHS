using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaselinkerConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "stock",
                table: "Product",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "sku",
                table: "Product",
                newName: "Sku");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ean",
                table: "Product",
                newName: "Ean");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Product",
                newName: "AveragePrice");

            migrationBuilder.AddColumn<double>(
                name: "AverageGrossPriceBuy",
                table: "Product",
                type: "float(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageGrossPriceBuy",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Product",
                newName: "stock");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Product",
                newName: "sku");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Ean",
                table: "Product",
                newName: "ean");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AveragePrice",
                table: "Product",
                newName: "price");
        }
    }
}
