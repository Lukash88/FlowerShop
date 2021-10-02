using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class ChangeDbSetReservationsStatusToReservationStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ReservationStatus_ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationStatus",
                table: "ReservationStatus");

            migrationBuilder.RenameTable(
                name: "ReservationStatus",
                newName: "ReservationStates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationStates",
                table: "ReservationStates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ReservationStates_ReservationStatusId",
                table: "Reservation",
                column: "ReservationStatusId",
                principalTable: "ReservationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ReservationStates_ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationStates",
                table: "ReservationStates");

            migrationBuilder.RenameTable(
                name: "ReservationStates",
                newName: "ReservationStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationStatus",
                table: "ReservationStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ReservationStatus_ReservationStatusId",
                table: "Reservation",
                column: "ReservationStatusId",
                principalTable: "ReservationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
