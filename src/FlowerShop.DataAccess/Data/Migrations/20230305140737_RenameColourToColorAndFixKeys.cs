using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class RenameColourToColorAndFixKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecorationsOrderDetails_Decorations_DecorationId",
                table: "DecorationsOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DecorationsOrderDetails_OrderDetails_OrderDetailId",
                table: "DecorationsOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DecorationsOrderDetails",
                table: "DecorationsOrderDetails");

            migrationBuilder.RenameTable(
                name: "DecorationsOrderDetails",
                newName: "DecorationOrderDetails");

            migrationBuilder.RenameColumn(
                name: "Colour",
                table: "Flowers",
                newName: "Color");

            migrationBuilder.RenameIndex(
                name: "IX_DecorationsOrderDetails_OrderDetailId",
                table: "DecorationOrderDetails",
                newName: "IX_DecorationOrderDetails_OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DecorationOrderDetails",
                table: "DecorationOrderDetails",
                columns: new[] { "DecorationId", "OrderDetailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DecorationOrderDetails_Decorations_DecorationId",
                table: "DecorationOrderDetails",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DecorationOrderDetails_OrderDetails_OrderDetailId",
                table: "DecorationOrderDetails",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecorationOrderDetails_Decorations_DecorationId",
                table: "DecorationOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DecorationOrderDetails_OrderDetails_OrderDetailId",
                table: "DecorationOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DecorationOrderDetails",
                table: "DecorationOrderDetails");

            migrationBuilder.RenameTable(
                name: "DecorationOrderDetails",
                newName: "DecorationsOrderDetails");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Flowers",
                newName: "Colour");

            migrationBuilder.RenameIndex(
                name: "IX_DecorationOrderDetails_OrderDetailId",
                table: "DecorationsOrderDetails",
                newName: "IX_DecorationsOrderDetails_OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DecorationsOrderDetails",
                table: "DecorationsOrderDetails",
                columns: new[] { "DecorationId", "OrderDetailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DecorationsOrderDetails_Decorations_DecorationId",
                table: "DecorationsOrderDetails",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DecorationsOrderDetails_OrderDetails_OrderDetailId",
                table: "DecorationsOrderDetails",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
