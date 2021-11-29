using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class AddServicePriceAndSetAsNullableInReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "Reservations",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Reservations");
        }
    }
}