using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialConnect.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "566f7a24-8980-4195-b43f-2e55a00975bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74713b6-46e6-4295-bd2a-25f41221d6ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73e91fdc-0d71-4081-a984-8ddf0690b9c2", null, "User", "USER" },
                    { "f620f23e-0799-48a0-a5a4-a8fbeb4c0d24", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e91fdc-0d71-4081-a984-8ddf0690b9c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f620f23e-0799-48a0-a5a4-a8fbeb4c0d24");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "566f7a24-8980-4195-b43f-2e55a00975bd", null, "Admin", null },
                    { "e74713b6-46e6-4295-bd2a-25f41221d6ef", null, "User", null }
                });
        }
    }
}
