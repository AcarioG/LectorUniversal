using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class change_name_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenderBooks_Books_BookId",
                table: "GenderBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "GenderBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "GenderBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks",
                columns: new[] { "GenderId", "BooksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenderBooks_Books_BookId",
                table: "GenderBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenderBooks_Books_BookId",
                table: "GenderBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "GenderBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "GenderBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks",
                columns: new[] { "GenderId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenderBooks_Books_BookId",
                table: "GenderBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
