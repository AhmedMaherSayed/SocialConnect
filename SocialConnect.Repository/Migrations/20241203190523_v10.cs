using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialConnect.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a0e4746-dcea-48b8-91b9-4cd4c1fba5cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7441980d-6912-41f0-a00f-9d659ff94a50");

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Notficiations",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2befd694-88c2-44e4-99cd-1ee7bba22bbe", null, "User", "USER" },
                    { "c9cf454c-f0f9-4c2a-9218-32957f87d44c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2befd694-88c2-44e4-99cd-1ee7bba22bbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9cf454c-f0f9-4c2a-9218-32957f87d44c");

            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Notficiations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a0e4746-dcea-48b8-91b9-4cd4c1fba5cc", null, "User", "USER" },
                    { "7441980d-6912-41f0-a00f-9d659ff94a50", null, "Admin", "ADMIN" }
                });
        }
    }
}
