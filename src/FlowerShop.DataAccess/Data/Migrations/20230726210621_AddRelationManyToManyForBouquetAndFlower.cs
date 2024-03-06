using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class AddRelationManyToManyForBouquetAndFlower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BouquetsFlowers",
                columns: table => new
                {
                    BouquetId = table.Column<int>(type: "int", nullable: false),
                    FlowerId = table.Column<int>(type: "int", nullable: false),
                    FlowerQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetsFlowers", x => new { x.BouquetId, x.FlowerId });
                    table.ForeignKey(
                        name: "FK_BouquetsFlowers_Products_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BouquetsFlowers_Products_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetsFlowers_FlowerId",
                table: "BouquetsFlowers",
                column: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetsFlowers");
        }
    }
}
