using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentSummaryAddedToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentSummary_Brand",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentSummary_ExpMonth",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentSummary_ExpYear",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentSummary_Last4",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentSummary_Brand",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentSummary_ExpMonth",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentSummary_ExpYear",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentSummary_Last4",
                table: "Orders");
        }
    }
}
