using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllegroConnector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedExpiresInForAllegroOauthTokenToDateTimeInsteadInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresIn",
                table: "AllegroOAuthTokens");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresIn",
                table: "AllegroOAuthTokens",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresIn",
            table: "AllegroOAuthTokens");

            migrationBuilder.AddColumn<int>(
                name: "ExpiresIn",
                table: "AllegroOAuthTokens",
                type: "int",
                nullable: true);
        }
    }
}
