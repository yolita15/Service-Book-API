using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceBook.API.Migrations
{
    public partial class ImageUrlForObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Objects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Objects");
        }
    }
}
