using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceBook.API.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Types_TypeId",
                table: "Objects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "ObjectTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectTypes",
                table: "ObjectTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_ObjectTypes_TypeId",
                table: "Objects",
                column: "TypeId",
                principalTable: "ObjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_ObjectTypes_TypeId",
                table: "Objects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectTypes",
                table: "ObjectTypes");

            migrationBuilder.RenameTable(
                name: "ObjectTypes",
                newName: "Types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Types_TypeId",
                table: "Objects",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
