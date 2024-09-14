using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaselinkerConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitInternalCommandsForBaseLinker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "baselinker");

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                schema: "baselinker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCommands", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalCommands",
                schema: "baselinker");
        }
    }
}
