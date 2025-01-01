using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class renamecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_UID",
                table: "ClientRequestDeveloper");

            migrationBuilder.RenameColumn(
                name: "UID",
                table: "ClientRequestDeveloper",
                newName: "developerid");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequestDeveloper_UID",
                table: "ClientRequestDeveloper",
                newName: "IX_ClientRequestDeveloper_developerid");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_developerid",
                table: "ClientRequestDeveloper",
                column: "developerid",
                principalTable: "Developer",
                principalColumn: "DeveloperID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_developerid",
                table: "ClientRequestDeveloper");

            migrationBuilder.RenameColumn(
                name: "developerid",
                table: "ClientRequestDeveloper",
                newName: "UID");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequestDeveloper_developerid",
                table: "ClientRequestDeveloper",
                newName: "IX_ClientRequestDeveloper_UID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequestDeveloper_Developer_UID",
                table: "ClientRequestDeveloper",
                column: "UID",
                principalTable: "Developer",
                principalColumn: "DeveloperID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
