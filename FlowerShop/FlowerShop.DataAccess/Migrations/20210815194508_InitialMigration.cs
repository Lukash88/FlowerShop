using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventStreet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventPostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDateAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsPaymentConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Invoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReceipt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
