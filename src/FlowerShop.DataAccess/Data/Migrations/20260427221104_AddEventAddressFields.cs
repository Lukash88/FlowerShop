using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEventAddressFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventStreet",
                table: "Reservations",
                newName: "EventState");

            migrationBuilder.AddColumn<string>(
                name: "EventCountry",
                table: "Reservations",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventLine1",
                table: "Reservations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventLine2",
                table: "Reservations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventCountry",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventLine1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventLine2",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "EventState",
                table: "Reservations",
                newName: "EventStreet");
        }
    }
}
