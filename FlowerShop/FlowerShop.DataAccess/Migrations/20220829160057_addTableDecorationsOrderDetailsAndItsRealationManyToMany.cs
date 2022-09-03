using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class addTableDecorationsOrderDetailsAndItsRealationManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecorationOrderDetail");

            migrationBuilder.CreateTable(
                name: "DecorationsOrderDetails",
                columns: table => new
                {
                    DecorationId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    DecorationQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationsOrderDetails", x => new { x.DecorationId, x.OrderDetailId });
                    table.ForeignKey(
                        name: "FK_DecorationsOrderDetails_Decorations_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecorationsOrderDetails_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecorationsOrderDetails_OrderDetailId",
                table: "DecorationsOrderDetails",
                column: "OrderDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecorationsOrderDetails");

            migrationBuilder.CreateTable(
                name: "DecorationOrderDetail",
                columns: table => new
                {
                    DecorationsId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationOrderDetail", x => new { x.DecorationsId, x.OrderDetailsId });
                    table.ForeignKey(
                        name: "FK_DecorationOrderDetail_Decorations_DecorationsId",
                        column: x => x.DecorationsId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecorationOrderDetail_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecorationOrderDetail_OrderDetailsId",
                table: "DecorationOrderDetail",
                column: "OrderDetailsId");
        }
    }
}
