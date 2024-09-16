using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaselinkerConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "baselinker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Product",
                schema: "baselinker",
                newName: "Product");
        }
    }
}
