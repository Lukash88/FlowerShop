using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class removedOrderItems_ReservationStates_AddedORders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetOrderDetail_OrderDetail_OrderDetailsId",
                table: "BouquetOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DecorationOrderDetail_OrderDetail_OrderDetailsId",
                table: "DecorationOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Reservations_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_OrderDetail_OrderDetailsId",
                table: "OrderDetailProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Reservations_OrderId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderItems",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetOrderDetail_OrderDetails_OrderDetailsId",
                table: "BouquetOrderDetail",
                column: "OrderDetailsId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DecorationOrderDetail_OrderDetails_OrderDetailsId",
                table: "DecorationOrderDetail",
                column: "OrderDetailsId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_OrderDetails_OrderDetailsId",
                table: "OrderDetailProduct",
                column: "OrderDetailsId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Orders_OrderId",
                table: "Reservation",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetOrderDetail_OrderDetails_OrderDetailsId",
                table: "BouquetOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DecorationOrderDetail_OrderDetails_OrderDetailsId",
                table: "DecorationOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_OrderDetails_OrderDetailsId",
                table: "OrderDetailProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Orders_OrderId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderItem",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetOrderDetail_OrderDetail_OrderDetailsId",
                table: "BouquetOrderDetail",
                column: "OrderDetailsId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DecorationOrderDetail_OrderDetail_OrderDetailsId",
                table: "DecorationOrderDetail",
                column: "OrderDetailsId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Reservations_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_OrderDetail_OrderDetailsId",
                table: "OrderDetailProduct",
                column: "OrderDetailsId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Reservations_OrderId",
                table: "Reservation",
                column: "OrderId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
