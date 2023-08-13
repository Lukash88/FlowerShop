using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class RemoveRelationBouquetFlower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetsFlowers_Bouquets_BouquetId",
                table: "BouquetsFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetsFlowers_Flowers_FlowerId",
                table: "BouquetsFlowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetsFlowers",
                table: "BouquetsFlowers");

            migrationBuilder.RenameTable(
                name: "BouquetsFlowers",
                newName: "BouquetFlowers");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetsFlowers_FlowerId",
                table: "BouquetFlowers",
                newName: "IX_BouquetFlowers_FlowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetFlowers",
                table: "BouquetFlowers",
                columns: new[] { "BouquetId", "FlowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetFlowers_Bouquets_BouquetId",
                table: "BouquetFlowers",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetFlowers_Flowers_FlowerId",
                table: "BouquetFlowers",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetFlowers_Bouquets_BouquetId",
                table: "BouquetFlowers");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetFlowers_Flowers_FlowerId",
                table: "BouquetFlowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetFlowers",
                table: "BouquetFlowers");

            migrationBuilder.RenameTable(
                name: "BouquetFlowers",
                newName: "BouquetsFlowers");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetFlowers_FlowerId",
                table: "BouquetsFlowers",
                newName: "IX_BouquetsFlowers_FlowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetsFlowers",
                table: "BouquetsFlowers",
                columns: new[] { "BouquetId", "FlowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetsFlowers_Bouquets_BouquetId",
                table: "BouquetsFlowers",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetsFlowers_Flowers_FlowerId",
                table: "BouquetsFlowers",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
