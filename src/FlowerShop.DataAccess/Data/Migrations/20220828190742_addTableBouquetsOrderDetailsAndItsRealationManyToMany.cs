using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class addTableBouquetsOrderDetailsAndItsRealationManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetOrderDetail");

            migrationBuilder.CreateTable(
                name: "BouquetsOrderDetails",
                columns: table => new
                {
                    BouquetId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    BouquetQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetsOrderDetails", x => new { x.BouquetId, x.OrderDetailId });
                    table.ForeignKey(
                        name: "FK_BouquetsOrderDetails_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetsOrderDetails_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetsOrderDetails_OrderDetailId",
                table: "BouquetsOrderDetails",
                column: "OrderDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetsOrderDetails");

            migrationBuilder.CreateTable(
                name: "BouquetOrderDetail",
                columns: table => new
                {
                    BouquetsId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetOrderDetail", x => new { x.BouquetsId, x.OrderDetailsId });
                    table.ForeignKey(
                        name: "FK_BouquetOrderDetail_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetOrderDetail_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetOrderDetail_OrderDetailsId",
                table: "BouquetOrderDetail",
                column: "OrderDetailsId");
        }
    }
}
