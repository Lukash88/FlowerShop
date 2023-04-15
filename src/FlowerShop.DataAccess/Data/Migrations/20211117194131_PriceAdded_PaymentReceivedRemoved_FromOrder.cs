using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class PriceAdded_PaymentReceivedRemoved_FromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentReceipt",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PaymentReceipt",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
