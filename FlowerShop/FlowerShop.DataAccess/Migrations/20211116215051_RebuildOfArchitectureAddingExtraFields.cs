using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class RebuildOfArchitectureAddingExtraFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Reservations_ReservationId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "BouquetOrderItem");

            migrationBuilder.DropTable(
                name: "DecorationOrderItem");

            migrationBuilder.DropTable(
                name: "OrderItemProduct");

            migrationBuilder.DropTable(
                name: "ReservationStates");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_InvoiceId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ReservationId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DateOfEvent",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventCity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventPostalCode",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventStreet",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsDateAvailable",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "ReservedOn",
                table: "Reservations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Decorations",
                newName: "StockLevel");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Bouquets",
                newName: "StockLevel");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockLevel",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "StockLevel",
            //    table: "Flowers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "OrderDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderDetail",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

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
                        name: "FK_BouquetOrderDetail_OrderDetail_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_DecorationOrderDetail_OrderDetail_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailProduct",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailProduct", x => new { x.OrderDetailsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderDetailProduct_OrderDetail_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    ReservedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDateAvailable = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Reservations_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BouquetOrderDetail_OrderDetailsId",
                table: "BouquetOrderDetail",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_DecorationOrderDetail_OrderDetailsId",
                table: "DecorationOrderDetail",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailProduct_ProductsId",
                table: "OrderDetailProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_OrderId",
                table: "Reservation",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Reservations_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Reservations_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropTable(
                name: "BouquetOrderDetail");

            migrationBuilder.DropTable(
                name: "DecorationOrderDetail");

            migrationBuilder.DropTable(
                name: "OrderDetailProduct");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StockLevel",
                table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "StockLevel",
            //    table: "Flowers");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reservations",
                newName: "ReservedOn");

            migrationBuilder.RenameColumn(
                name: "StockLevel",
                table: "Decorations",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "StockLevel",
                table: "Bouquets",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEvent",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventCity",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Reservations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventPostalCode",
                table: "Reservations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventStreet",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Reservations",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDateAvailable",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationStates_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Reservations_InvoiceId",
                table: "Reservations",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ReservationId",
                table: "OrderDetails",
                column: "ReservationId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderDetailId",
                table: "OrderItems",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStates_ReservationId",
                table: "ReservationStates",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Reservations_ReservationId",
                table: "OrderDetails",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
