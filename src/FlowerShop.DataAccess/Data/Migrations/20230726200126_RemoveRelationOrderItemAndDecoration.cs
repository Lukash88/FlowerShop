using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class RemoveRelationOrderItemAndDecoration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_DecorationId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_DecorationId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DecorationId",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecorationId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DecorationId",
                table: "OrderItems",
                column: "DecorationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_DecorationId",
                table: "OrderItems",
                column: "DecorationId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
