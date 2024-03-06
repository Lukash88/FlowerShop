using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class RemoveRelationOrderDetailBouquet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetsOrderDetails_Bouquets_BouquetId",
                table: "BouquetsOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetsOrderDetails_OrderDetails_OrderDetailId",
                table: "BouquetsOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetsOrderDetails",
                table: "BouquetsOrderDetails");

            migrationBuilder.RenameTable(
                name: "BouquetsOrderDetails",
                newName: "BouquetOrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetsOrderDetails_OrderDetailId",
                table: "BouquetOrderDetails",
                newName: "IX_BouquetOrderDetails_OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetOrderDetails",
                table: "BouquetOrderDetails",
                columns: new[] { "BouquetId", "OrderDetailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetOrderDetails_Bouquets_BouquetId",
                table: "BouquetOrderDetails",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetOrderDetails_OrderDetails_OrderDetailId",
                table: "BouquetOrderDetails",
                column: "OrderDetailId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetOrderDetails_Bouquets_BouquetId",
                table: "BouquetOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetOrderDetails_OrderDetails_OrderDetailId",
                table: "BouquetOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetOrderDetails",
                table: "BouquetOrderDetails");

            migrationBuilder.RenameTable(
                name: "BouquetOrderDetails",
                newName: "BouquetsOrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetOrderDetails_OrderDetailId",
                table: "BouquetsOrderDetails",
                newName: "IX_BouquetsOrderDetails_OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetsOrderDetails",
                table: "BouquetsOrderDetails",
                columns: new[] { "BouquetId", "OrderDetailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetsOrderDetails_Bouquets_BouquetId",
                table: "BouquetsOrderDetails",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetsOrderDetails_OrderDetails_OrderDetailId",
                table: "BouquetsOrderDetails",
                column: "OrderDetailId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
