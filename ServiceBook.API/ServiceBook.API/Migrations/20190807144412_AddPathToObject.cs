using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceBook.API.Migrations
{
    public partial class AddPathToObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Objects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Objects");
        }
    }
}
