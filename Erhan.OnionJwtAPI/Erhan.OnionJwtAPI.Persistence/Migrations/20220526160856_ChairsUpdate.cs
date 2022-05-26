using Microsoft.EntityFrameworkCore.Migrations;

namespace Erhan.MovieTicketSystem.Persistence.Migrations
{
    public partial class ChairsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChairNumber",
                table: "Chair");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChairNumber",
                table: "Chair",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
