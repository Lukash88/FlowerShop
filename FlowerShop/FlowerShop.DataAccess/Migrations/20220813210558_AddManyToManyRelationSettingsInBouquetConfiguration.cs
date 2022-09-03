using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class AddManyToManyRelationSettingsInBouquetConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetsFlowers");

            migrationBuilder.CreateTable(
                name: "BouquetFlower",
                columns: table => new
                {
                    BouquetsId = table.Column<int>(type: "int", nullable: false),
                    FlowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetFlower", x => new { x.BouquetsId, x.FlowersId });
                    table.ForeignKey(
                        name: "FK_BouquetFlower_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetFlower_Flowers_FlowersId",
                        column: x => x.FlowersId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetFlower_FlowersId",
                table: "BouquetFlower",
                column: "FlowersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetFlower");

            migrationBuilder.CreateTable(
                name: "BouquetsFlowers",
                columns: table => new
                {
                    BouquetsId = table.Column<int>(type: "int", nullable: false),
                    FlowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetsFlowers", x => new { x.BouquetsId, x.FlowersId });
                    table.ForeignKey(
                        name: "FK_BouquetsFlowers_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetsFlowers_Flowers_FlowersId",
                        column: x => x.FlowersId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetsFlowers_FlowersId",
                table: "BouquetsFlowers",
                column: "FlowersId");
        }
    }
}
