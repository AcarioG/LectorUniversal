using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class bookid_added_to_chapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "Chapters",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_BooksId",
                table: "Chapters",
                newName: "IX_Chapters_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Chapters",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_BookId",
                table: "Chapters",
                newName: "IX_Chapters_BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
