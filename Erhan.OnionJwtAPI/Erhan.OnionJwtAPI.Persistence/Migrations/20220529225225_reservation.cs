using Microsoft.EntityFrameworkCore.Migrations;

namespace Erhan.MovieTicketSystem.Persistence.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ChairId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ChairId_ReservationDate",
                table: "Reservations",
                columns: new[] { "ChairId", "ReservationDate" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ChairId_ReservationDate",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ChairId",
                table: "Reservations",
                column: "ChairId");
        }
    }
}
