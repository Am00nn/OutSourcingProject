using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInModeTeamsMamber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperID",
                table: "TeamMember",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                columns: new[] { "TeamID", "DeveloperID" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_DeveloperID",
                table: "TeamMember",
                column: "DeveloperID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Developer_DeveloperID",
                table: "TeamMember",
                column: "DeveloperID",
                principalTable: "Developer",
                principalColumn: "DeveloperID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Developer_DeveloperID",
                table: "TeamMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_TeamMember_DeveloperID",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "TeamMember");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "TeamID");
        }
    }
}
