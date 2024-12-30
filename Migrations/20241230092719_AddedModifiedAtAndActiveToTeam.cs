using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedModifiedAtAndActiveToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Teams");
        }
    }
}
