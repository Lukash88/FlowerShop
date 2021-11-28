using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class ChangeInvoiceMaxLengthTo100InOrderConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Invoice",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Invoice",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
