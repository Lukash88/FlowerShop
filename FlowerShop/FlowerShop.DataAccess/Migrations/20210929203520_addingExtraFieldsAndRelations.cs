using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Migrations
{
    public partial class addingExtraFieldsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Bouquets_BouquetId",
                table: "Flowers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderDetails_OrderDetailsId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_BouquetId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "BouquetId",
                table: "Flowers");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsId",
                table: "OrderItems",
                newName: "OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderDetailsId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderDetailId");

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EventStreet",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EventPostalCode",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EventCity",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationStatusId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Decorations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Decorations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "Decorations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BouquetFlower",
                columns: table => new
                {
                    BouquetsId = table.Column<int>(type: "int", nullable: false),
                    FlowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetFlower", x => new { x.BouquetsId, x.FlowersId });
                    table.ForeignKey(
                        name: "FK_BouquetFlower_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetFlower_Flowers_FlowersId",
                        column: x => x.FlowersId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationStatusId",
                table: "Reservation",
                column: "ReservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ReservationId",
                table: "OrderDetails",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BouquetFlower_FlowersId",
                table: "BouquetFlower",
                column: "FlowersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Reservation_ReservationId",
                table: "OrderDetails",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderDetails_OrderDetailId",
                table: "OrderItems",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ReservationStatus_ReservationStatusId",
                table: "Reservation",
                column: "ReservationStatusId",
                principalTable: "ReservationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Reservation_ReservationId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderDetails_OrderDetailId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ReservationStatus_ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "BouquetFlower");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ReservationId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationStatusId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Decorations");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Decorations");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Decorations");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderItems",
                newName: "OrderDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderDetailId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderDetailsId");

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventStreet",
                table: "Reservation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventPostalCode",
                table: "Reservation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventCity",
                table: "Reservation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BouquetId",
                table: "Flowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_BouquetId",
                table: "Flowers",
                column: "BouquetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Bouquets_BouquetId",
                table: "Flowers",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderDetails_OrderDetailsId",
                table: "OrderItems",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
