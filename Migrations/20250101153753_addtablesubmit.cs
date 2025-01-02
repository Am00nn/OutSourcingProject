using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addtablesubmit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmitRequestModel",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeveloperID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmitRequestModel", x => x.SId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmitRequestModel");
        }
    }
}
