using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAllegroOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "offers");

            migrationBuilder.CreateTable(
                name: "AllegroOffers",
                schema: "offers",
                columns: table => new
                {
                    AllegroOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    PriceGross = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllegroOffers", x => x.AllegroOfferId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllegroOffers",
                schema: "offers");
        }
    }
}
