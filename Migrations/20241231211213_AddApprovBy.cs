using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproveBy",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsApproved",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveBy",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Client");
        }
    }
}
