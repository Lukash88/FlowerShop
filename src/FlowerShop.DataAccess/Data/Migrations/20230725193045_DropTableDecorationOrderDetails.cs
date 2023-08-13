using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class DropTableDecorationOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecorationOrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "DecorationId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DecorationId",
                table: "OrderItems",
                column: "DecorationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Decorations_DecorationId",
                table: "OrderItems",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Decorations_DecorationId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_DecorationId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DecorationId",
                table: "OrderItems");

            migrationBuilder.CreateTable(
                name: "DecorationOrderDetails",
                columns: table => new
                {
                    DecorationId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    DecorationQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationOrderDetails", x => new { x.DecorationId, x.OrderDetailId });
                    table.ForeignKey(
                        name: "FK_DecorationOrderDetails_Decorations_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecorationOrderDetails_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecorationOrderDetails_OrderDetailId",
                table: "DecorationOrderDetails",
                column: "OrderDetailId");
        }
    }
}
