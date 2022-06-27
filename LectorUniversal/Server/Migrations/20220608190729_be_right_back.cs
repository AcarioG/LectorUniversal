using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class be_right_back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterBooks");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ChapterBooks",
                columns: table => new
                {
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterBooks", x => new { x.ChapterId, x.BookId });
                    table.ForeignKey(
                        name: "FK_ChapterBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterBooks_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterBooks_BookId",
                table: "ChapterBooks",
                column: "BookId");
        }
    }
}
