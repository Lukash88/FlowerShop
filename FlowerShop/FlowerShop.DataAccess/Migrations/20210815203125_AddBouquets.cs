using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class AddBouquets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetOrderItems_Bouquet_BouquetsId",
                table: "BouquetOrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bouquet",
                table: "Bouquet");

            migrationBuilder.RenameTable(
                name: "Bouquet",
                newName: "Bouquets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bouquets",
                table: "Bouquets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetOrderItems_Bouquets_BouquetsId",
                table: "BouquetOrderItems",
                column: "BouquetsId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetOrderItems_Bouquets_BouquetsId",
                table: "BouquetOrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bouquets",
                table: "Bouquets");

            migrationBuilder.RenameTable(
                name: "Bouquets",
                newName: "Bouquet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bouquet",
                table: "Bouquet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetOrderItems_Bouquet_BouquetsId",
                table: "BouquetOrderItems",
                column: "BouquetsId",
                principalTable: "Bouquet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
