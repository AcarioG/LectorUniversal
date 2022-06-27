using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class relationship_book_to_chapter_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_BooksId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Chapters");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BookId",
                table: "Chapters",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_BookId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Chapters");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Chapters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BooksId",
                table: "Chapters",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BooksId",
                table: "Chapters",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
