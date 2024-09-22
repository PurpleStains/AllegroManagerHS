using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncomeAndPackageFeeColumnsOnOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Income",
                schema: "offers",
                table: "AllegroOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PackageFee",
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
                name: "Income",
                schema: "offers",
                table: "AllegroOffers");

            migrationBuilder.DropColumn(
                name: "PackageFee",
                schema: "offers",
                table: "AllegroOffers");
        }
    }
}
