using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class change_type_book_editorial_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksEditorials");

            migrationBuilder.AddColumn<int>(
                name: "EditorialId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_EditorialId",
                table: "Books",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Editorials_EditorialId",
                table: "Books",
                column: "EditorialId",
                principalTable: "Editorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editorials_EditorialId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_EditorialId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EditorialId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BooksEditorials",
                columns: table => new
                {
                    EditorialId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksEditorials", x => new { x.EditorialId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BooksEditorials_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksEditorials_Editorials_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksEditorials_BookId",
                table: "BooksEditorials",
                column: "BookId",
                unique: true);
        }
    }
}
