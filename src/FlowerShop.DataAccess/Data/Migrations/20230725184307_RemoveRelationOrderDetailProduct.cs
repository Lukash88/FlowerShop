using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class RemoveRelationOrderDetailProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrderDetails_OrderDetails_OrderDetailId",
                table: "ProductsOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrderDetails_Products_ProductId",
                table: "ProductsOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsOrderDetails",
                table: "ProductsOrderDetails");

            migrationBuilder.RenameTable(
                name: "ProductsOrderDetails",
                newName: "ProductOrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsOrderDetails_ProductId",
                table: "ProductOrderDetails",
                newName: "IX_ProductOrderDetails_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderDetails",
                table: "ProductOrderDetails",
                columns: new[] { "OrderDetailId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderDetails_OrderDetails_OrderDetailId",
                table: "ProductOrderDetails",
                column: "OrderDetailId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderDetails_Products_ProductId",
                table: "ProductOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderDetails_OrderDetails_OrderDetailId",
                table: "ProductOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderDetails_Products_ProductId",
                table: "ProductOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderDetails",
                table: "ProductOrderDetails");

            migrationBuilder.RenameTable(
                name: "ProductOrderDetails",
                newName: "ProductsOrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrderDetails_ProductId",
                table: "ProductsOrderDetails",
                newName: "IX_ProductsOrderDetails_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsOrderDetails",
                table: "ProductsOrderDetails",
                columns: new[] { "OrderDetailId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrderDetails_OrderDetails_OrderDetailId",
                table: "ProductsOrderDetails",
                column: "OrderDetailId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrderDetails_Products_ProductId",
                table: "ProductsOrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
