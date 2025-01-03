using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_developerid",
                table: "ClientRequestDeveloper");

            migrationBuilder.RenameColumn(
                name: "developerid",
                table: "ClientRequestDeveloper",
                newName: "DeveloperID");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequestDeveloper_developerid",
                table: "ClientRequestDeveloper",
                newName: "IX_ClientRequestDeveloper_DeveloperID");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ClientRequestDeveloper",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_DeveloperID",
                table: "ClientRequestDeveloper",
                column: "DeveloperID",
                principalTable: "Developer",
                principalColumn: "DeveloperID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_DeveloperID",
                table: "ClientRequestDeveloper");

            migrationBuilder.RenameColumn(
                name: "DeveloperID",
                table: "ClientRequestDeveloper",
                newName: "developerid");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequestDeveloper_DeveloperID",
                table: "ClientRequestDeveloper",
                newName: "IX_ClientRequestDeveloper_developerid");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ClientRequestDeveloper",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_developerid",
                table: "ClientRequestDeveloper",
                column: "developerid",
                principalTable: "Developer",
                principalColumn: "DeveloperID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
