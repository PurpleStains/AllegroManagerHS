using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMarginAndAllegroFeeColumnsOnOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AllegroFee",
                schema: "offers",
                table: "AllegroOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Margin",
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
                name: "AllegroFee",
                schema: "offers",
                table: "AllegroOffers");

            migrationBuilder.DropColumn(
                name: "Margin",
                schema: "offers",
                table: "AllegroOffers");
        }
    }
}
