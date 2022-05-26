using Microsoft.EntityFrameworkCore.Migrations;

namespace Erhan.MovieTicketSystem.Persistence.Migrations
{
    public partial class ChairsUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_AppUser_AppUserId",
                table: "Chair");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Chair",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_AppUser_AppUserId",
                table: "Chair",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_AppUser_AppUserId",
                table: "Chair");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Chair",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_AppUser_AppUserId",
                table: "Chair",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
