using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsClientApproved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserApproved",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsApprove",
                table: "Client",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApprove",
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
