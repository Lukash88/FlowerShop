using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class ChangeCategoryMaxLengthTo100InOrderDetailConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "OrderDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "OrderDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
