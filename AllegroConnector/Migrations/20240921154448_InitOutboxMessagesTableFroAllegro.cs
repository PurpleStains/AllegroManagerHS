using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitOutboxMessagesTableFroAllegro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "meetings",
                newName: "OutboxMessages",
                newSchema: "allegro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "meetings");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                schema: "allegro",
                newName: "OutboxMessages",
                newSchema: "meetings");
        }
    }
}
