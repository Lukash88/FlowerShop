using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class ChangeOcaasionTypeFromStringToEnumInBouquet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Occasion",
                table: "Bouquets",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Bouquets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Bouquets");

            migrationBuilder.AlterColumn<string>(
                name: "Occasion",
                table: "Bouquets",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200);
        }
    }
}
