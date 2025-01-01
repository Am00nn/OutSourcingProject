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
            migrationBuilder.DropColumn(
                name: "IsUserApproved",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "DocumentLink",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsApprove",
                table: "Developer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsApproveBy",
                table: "Developer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Developer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DeveloperID",
                table: "ClientRequestTeam",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TID",
                table: "ClientRequestTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "ClientRequestDeveloper",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApproveBy",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApprove",
                table: "Client",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Client",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequestTeam_DeveloperID",
                table: "ClientRequestTeam",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequestTeam_TID",
                table: "ClientRequestTeam",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequestDeveloper_UID",
                table: "ClientRequestDeveloper",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_UID",
                table: "ClientRequestDeveloper",
                column: "UID",
                principalTable: "Developer",
                principalColumn: "DeveloperID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestTeam_Developer_DeveloperID",
                table: "ClientRequestTeam",
                column: "DeveloperID",
                principalTable: "Developer",
                principalColumn: "DeveloperID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestTeam_Teams_TID",
                table: "ClientRequestTeam",
                column: "TID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_UID",
                table: "ClientRequestDeveloper");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestTeam_Developer_DeveloperID",
                table: "ClientRequestTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestTeam_Teams_TID",
                table: "ClientRequestTeam");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequestTeam_DeveloperID",
                table: "ClientRequestTeam");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequestTeam_TID",
                table: "ClientRequestTeam");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequestDeveloper_UID",
                table: "ClientRequestDeveloper");

            migrationBuilder.DropColumn(
                name: "DocumentLink",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "IsApprove",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "IsApproveBy",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "ClientRequestTeam");

            migrationBuilder.DropColumn(
                name: "TID",
                table: "ClientRequestTeam");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "ClientRequestDeveloper");

            migrationBuilder.DropColumn(
                name: "ApproveBy",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IsApprove",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Client");

            migrationBuilder.AddColumn<bool>(
                name: "IsUserApproved",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
