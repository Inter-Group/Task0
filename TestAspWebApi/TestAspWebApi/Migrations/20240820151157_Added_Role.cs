using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAspWebApi.Migrations
{
    public partial class Added_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2db12939-35b7-4230-8b1f-cb21d985590b", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6629673f-8bd9-4f23-9fe2-223f1ae30a6d", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd9ecd94-4e33-480c-9fba-e4fbae76feea", null, "XuongTruong", "XUONGTRUONG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db12939-35b7-4230-8b1f-cb21d985590b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6629673f-8bd9-4f23-9fe2-223f1ae30a6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9ecd94-4e33-480c-9fba-e4fbae76feea");
        }
    }
}
