using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialConnect.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a072d57e-20a6-451f-87eb-67dc319e5964");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb3bd686-34e0-4e28-ba5f-4b81e296d4e9");

            migrationBuilder.CreateTable(
                name: "FrindsUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FrindsId_fk = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aprove = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModefiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrindsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrindsUsers_AspNetUsers_FrindsId_fk",
                        column: x => x.FrindsId_fk,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FrindsUsers_AspNetUsers_user_Id",
                        column: x => x.user_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notficiations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notficiations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a0e4746-dcea-48b8-91b9-4cd4c1fba5cc", null, "User", "USER" },
                    { "7441980d-6912-41f0-a00f-9d659ff94a50", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrindsUsers_FrindsId_fk",
                table: "FrindsUsers",
                column: "FrindsId_fk");

            migrationBuilder.CreateIndex(
                name: "IX_FrindsUsers_user_Id",
                table: "FrindsUsers",
                column: "user_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrindsUsers");

            migrationBuilder.DropTable(
                name: "Notficiations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a0e4746-dcea-48b8-91b9-4cd4c1fba5cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7441980d-6912-41f0-a00f-9d659ff94a50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a072d57e-20a6-451f-87eb-67dc319e5964", null, "User", "USER" },
                    { "bb3bd686-34e0-4e28-ba5f-4b81e296d4e9", null, "Admin", "ADMIN" }
                });
        }
    }
}
