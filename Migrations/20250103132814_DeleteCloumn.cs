using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCloumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApprove",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "IsApproveBy",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "ApproveBy",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IsApprove",
                table: "Client");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Developer",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Developer");

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
        }
    }
}
