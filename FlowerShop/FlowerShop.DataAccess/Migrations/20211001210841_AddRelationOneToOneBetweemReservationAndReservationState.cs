using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class AddRelationOneToOneBetweemReservationAndReservationState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ReservationStates_ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationStatusId",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "ReservationStates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStates_ReservationId",
                table: "ReservationStates",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationStates_Reservation_ReservationId",
                table: "ReservationStates",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationStates_Reservation_ReservationId",
                table: "ReservationStates");

            migrationBuilder.DropIndex(
                name: "IX_ReservationStates_ReservationId",
                table: "ReservationStates");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ReservationStates");

            migrationBuilder.AddColumn<int>(
                name: "ReservationStatusId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationStatusId",
                table: "Reservation",
                column: "ReservationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ReservationStates_ReservationStatusId",
                table: "Reservation",
                column: "ReservationStatusId",
                principalTable: "ReservationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
