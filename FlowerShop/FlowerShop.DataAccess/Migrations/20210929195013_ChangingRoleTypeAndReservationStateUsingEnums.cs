using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class ChangingRoleTypeAndReservationStateUsingEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationStates",
                table: "ReservationStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReservationStates",
                table: "ReservationStatus");

            migrationBuilder.AddColumn<string>(
                name: "RoleType",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
