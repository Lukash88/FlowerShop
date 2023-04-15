using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class SetSumInIrderConfigurationAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Orders",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldPrecision: 14,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Orders",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldPrecision: 14,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
