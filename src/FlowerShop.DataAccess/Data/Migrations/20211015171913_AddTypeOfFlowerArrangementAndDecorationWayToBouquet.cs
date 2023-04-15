using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class AddTypeOfFlowerArrangementAndDecorationWayToBouquet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecorationWay",
                table: "Bouquets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfArrangement",
                table: "Bouquets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecorationWay",
                table: "Bouquets");

            migrationBuilder.DropColumn(
                name: "TypeOfArrangement",
                table: "Bouquets");
        }
    }
}
