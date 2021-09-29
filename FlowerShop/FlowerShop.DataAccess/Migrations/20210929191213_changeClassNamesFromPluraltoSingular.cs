using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class changeClassNamesFromPluraltoSingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetOrderItems");

            migrationBuilder.DropTable(
                name: "DecorationsOrderItems");

            migrationBuilder.DropTable(
                name: "OrderItemsProducts");

            migrationBuilder.CreateTable(
                name: "BouquetOrderItem",
                columns: table => new
                {
                    BouquetsId = table.Column<int>(type: "int", nullable: false),
                    OrderItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetOrderItem", x => new { x.BouquetsId, x.OrderItemsId });
                    table.ForeignKey(
                        name: "FK_BouquetOrderItem_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetOrderItem_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DecorationOrderItem",
                columns: table => new
                {
                    DecorationsId = table.Column<int>(type: "int", nullable: false),
                    OrderItremsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationOrderItem", x => new { x.DecorationsId, x.OrderItremsId });
                    table.ForeignKey(
                        name: "FK_DecorationOrderItem_Decorations_DecorationsId",
                        column: x => x.DecorationsId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecorationOrderItem_OrderItems_OrderItremsId",
                        column: x => x.OrderItremsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemProduct",
                columns: table => new
                {
                    OrderItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemProduct", x => new { x.OrderItemsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderItemProduct_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetOrderItem_OrderItemsId",
                table: "BouquetOrderItem",
                column: "OrderItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_DecorationOrderItem_OrderItremsId",
                table: "DecorationOrderItem",
                column: "OrderItremsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemProduct_ProductsId",
                table: "OrderItemProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetOrderItem");

            migrationBuilder.DropTable(
                name: "DecorationOrderItem");

            migrationBuilder.DropTable(
                name: "OrderItemProduct");

            migrationBuilder.CreateTable(
                name: "BouquetOrderItems",
                columns: table => new
                {
                    BouquetsId = table.Column<int>(type: "int", nullable: false),
                    OrderItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetOrderItems", x => new { x.BouquetsId, x.OrderItemsId });
                    table.ForeignKey(
                        name: "FK_BouquetOrderItems_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetOrderItems_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DecorationsOrderItems",
                columns: table => new
                {
                    DecorationsId = table.Column<int>(type: "int", nullable: false),
                    OrderItremsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationsOrderItems", x => new { x.DecorationsId, x.OrderItremsId });
                    table.ForeignKey(
                        name: "FK_DecorationsOrderItems_Decorations_DecorationsId",
                        column: x => x.DecorationsId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecorationsOrderItems_OrderItems_OrderItremsId",
                        column: x => x.OrderItremsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemsProducts",
                columns: table => new
                {
                    OrderItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemsProducts", x => new { x.OrderItemsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderItemsProducts_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemsProducts_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetOrderItems_OrderItemsId",
                table: "BouquetOrderItems",
                column: "OrderItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_DecorationsOrderItems_OrderItremsId",
                table: "DecorationsOrderItems",
                column: "OrderItremsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemsProducts_ProductsId",
                table: "OrderItemsProducts",
                column: "ProductsId");
        }
    }
}
