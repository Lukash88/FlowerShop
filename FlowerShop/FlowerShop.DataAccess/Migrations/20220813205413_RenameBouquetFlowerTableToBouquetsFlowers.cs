using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class RenameBouquetFlowerTableToBouquetsFlowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetFlower_Bouquets_BouquetsId",
                table: "BouquetFlower");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetFlower_Flowers_FlowersId",
                table: "BouquetFlower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetFlower",
                table: "BouquetFlower");

            migrationBuilder.RenameTable(
                name: "BouquetFlower",
                newName: "BouquetsFlowers");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetFlower_FlowersId",
                table: "BouquetsFlowers",
                newName: "IX_BouquetsFlowers_FlowersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetsFlowers",
                table: "BouquetsFlowers",
                columns: new[] { "BouquetsId", "FlowersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetsFlowers_Bouquets_BouquetsId",
                table: "BouquetsFlowers",
                column: "BouquetsId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetsFlowers_Flowers_FlowersId",
                table: "BouquetsFlowers",
                column: "FlowersId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetsFlowers_Bouquets_BouquetsId",
                table: "BouquetsFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetsFlowers_Flowers_FlowersId",
                table: "BouquetsFlowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetsFlowers",
                table: "BouquetsFlowers");

            migrationBuilder.RenameTable(
                name: "BouquetsFlowers",
                newName: "BouquetFlower");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetsFlowers_FlowersId",
                table: "BouquetFlower",
                newName: "IX_BouquetFlower_FlowersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetFlower",
                table: "BouquetFlower",
                columns: new[] { "BouquetsId", "FlowersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetFlower_Bouquets_BouquetsId",
                table: "BouquetFlower",
                column: "BouquetsId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetFlower_Flowers_FlowersId",
                table: "BouquetFlower",
                column: "FlowersId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
