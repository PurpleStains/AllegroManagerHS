using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldForBuyPriceInAllegroOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BuyPriceGross",
                schema: "offers",
                table: "AllegroOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyPriceGross",
                schema: "offers",
                table: "AllegroOffers");
        }
    }
}
