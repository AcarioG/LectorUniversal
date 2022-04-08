using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Data.Migrations
{
    public partial class fix_gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks");

            migrationBuilder.DropIndex(
                name: "IX_GenderBooks_GenderId",
                table: "GenderBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks",
                columns: new[] { "GenderId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_GenderBooks_BookId",
                table: "GenderBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks");

            migrationBuilder.DropIndex(
                name: "IX_GenderBooks_BookId",
                table: "GenderBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderBooks",
                table: "GenderBooks",
                columns: new[] { "BookId", "GenderId" });

            migrationBuilder.CreateIndex(
                name: "IX_GenderBooks_GenderId",
                table: "GenderBooks",
                column: "GenderId");
        }
    }
}
