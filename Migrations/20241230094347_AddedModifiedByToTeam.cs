using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedModifiedByToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Teams");
        }
    }
}
