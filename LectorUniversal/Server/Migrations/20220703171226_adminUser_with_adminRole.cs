using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectorUniversal.Server.Migrations
{
    public partial class adminUser_with_adminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069ac571-eef5-4bba-99e1-037287a00ef1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6964fafb-f35f-4e02-b54b-c88aae976d0a", "e6f50230-61c4-4758-8118-1c9e8f545625", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f10bef8-3d68-4a7d-8262-7846e339e7d2", 0, "bfb6ef6e-e803-4a81-bc55-edbdbe25be53", "wilmervasquez219@gmail.com", true, true, null, "WILMERVASQUEZ219@GMAIL.COM", "ACARIOG", "AQAAAAEAACcQAAAAENyGMozmIMj3qkPBGtXK6uq+LtRPpYIKrwHenak+3N1YwR0QhffQS1TrcA05HRz8bg==", "8297500421", false, "XAAIWXV5PF3EPASY7ONECLRUAPKWSUBY", false, "AcarioG" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6964fafb-f35f-4e02-b54b-c88aae976d0a", "7f10bef8-3d68-4a7d-8262-7846e339e7d2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6964fafb-f35f-4e02-b54b-c88aae976d0a", "7f10bef8-3d68-4a7d-8262-7846e339e7d2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6964fafb-f35f-4e02-b54b-c88aae976d0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f10bef8-3d68-4a7d-8262-7846e339e7d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "069ac571-eef5-4bba-99e1-037287a00ef1", "49f33a92-5303-4a9f-8285-ef7baab9f2f0", "admin", "admin" });
        }
    }
}
