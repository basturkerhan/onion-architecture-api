using Microsoft.EntityFrameworkCore.Migrations;

namespace Erhan.MovieTicketSystem.Persistence.Migrations
{
    public partial class ChairsUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Chair",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chair_AppUserId",
                table: "Chair",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_AppUser_AppUserId",
                table: "Chair",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_AppUser_AppUserId",
                table: "Chair");

            migrationBuilder.DropIndex(
                name: "IX_Chair_AppUserId",
                table: "Chair");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Chair");
        }
    }
}
