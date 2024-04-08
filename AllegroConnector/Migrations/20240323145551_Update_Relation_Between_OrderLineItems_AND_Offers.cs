using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Relation_Between_OrderLineItems_AND_Offers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_AllegroOffers_OfferIdAllegroOfferId",
                schema: "orders",
                table: "OrderLineItems");

            migrationBuilder.RenameColumn(
                name: "OfferIdAllegroOfferId",
                schema: "orders",
                table: "OrderLineItems",
                newName: "AllegroOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItems_OfferIdAllegroOfferId",
                schema: "orders",
                table: "OrderLineItems",
                newName: "IX_OrderLineItems_AllegroOfferId");

            migrationBuilder.AddColumn<string>(
                name: "OfferId",
                schema: "orders",
                table: "OrderLineItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_AllegroOffers_AllegroOfferId",
                schema: "orders",
                table: "OrderLineItems",
                column: "AllegroOfferId",
                principalSchema: "offers",
                principalTable: "AllegroOffers",
                principalColumn: "AllegroOfferId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_AllegroOffers_AllegroOfferId",
                schema: "orders",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "OfferId",
                schema: "orders",
                table: "OrderLineItems");

            migrationBuilder.RenameColumn(
                name: "AllegroOfferId",
                schema: "orders",
                table: "OrderLineItems",
                newName: "OfferIdAllegroOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItems_AllegroOfferId",
                schema: "orders",
                table: "OrderLineItems",
                newName: "IX_OrderLineItems_OfferIdAllegroOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_AllegroOffers_OfferIdAllegroOfferId",
                schema: "orders",
                table: "OrderLineItems",
                column: "OfferIdAllegroOfferId",
                principalSchema: "offers",
                principalTable: "AllegroOffers",
                principalColumn: "AllegroOfferId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
