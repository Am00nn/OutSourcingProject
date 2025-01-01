using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIDToClientRevDevBecMissing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientReviewDeveloper_Client_ClientID",
                table: "ClientReviewDeveloper");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "ClientReviewDeveloper",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientReviewDeveloper_Client_ClientID",
                table: "ClientReviewDeveloper",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientReviewDeveloper_Client_ClientID",
                table: "ClientReviewDeveloper");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "ClientReviewDeveloper",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientReviewDeveloper_Client_ClientID",
                table: "ClientReviewDeveloper",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID");
        }
    }
}
