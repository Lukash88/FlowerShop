using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.DataAccess.Data.Migrations
{
    public partial class ImageUrlImageThumbnailUrlAddedToDecoration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Decorations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Decorations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Decorations");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Decorations");
        }
    }
}
