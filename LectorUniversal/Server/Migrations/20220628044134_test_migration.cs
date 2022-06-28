using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class test_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
