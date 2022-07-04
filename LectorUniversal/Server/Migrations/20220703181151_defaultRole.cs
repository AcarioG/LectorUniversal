using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class defaultRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6964fafb-f35f-4e02-b54b-c88aae976d0a",
                column: "ConcurrencyStamp",
                value: "06dd6ea1-f60b-4027-8060-d4b6e0fba349");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f9f3a7e-9bc6-4b14-943f-bf924b00f05d", "692f78a3-70f1-45b3-a489-69ef3fbade31", "default", "default" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f9f3a7e-9bc6-4b14-943f-bf924b00f05d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6964fafb-f35f-4e02-b54b-c88aae976d0a",
                column: "ConcurrencyStamp",
                value: "e6f50230-61c4-4758-8118-1c9e8f545625");
        }
    }
}
