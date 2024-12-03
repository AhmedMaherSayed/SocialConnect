using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialConnect.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Massages_Massages_MassageId_fk",
                table: "Massages");

            migrationBuilder.DropIndex(
                name: "IX_Massages_MassageId_fk",
                table: "Massages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e91fdc-0d71-4081-a984-8ddf0690b9c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f620f23e-0799-48a0-a5a4-a8fbeb4c0d24");

            migrationBuilder.DropColumn(
                name: "MassageId_fk",
                table: "Massages");

            migrationBuilder.RenameColumn(
                name: "UserIdID",
                table: "Massages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "MyID",
                table: "Massages",
                newName: "ReceiverId");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Massages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Massages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a072d57e-20a6-451f-87eb-67dc319e5964", null, "User", "USER" },
                    { "bb3bd686-34e0-4e28-ba5f-4b81e296d4e9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a072d57e-20a6-451f-87eb-67dc319e5964");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb3bd686-34e0-4e28-ba5f-4b81e296d4e9");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Massages");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Massages");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Massages",
                newName: "UserIdID");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Massages",
                newName: "MyID");

            migrationBuilder.AddColumn<string>(
                name: "MassageId_fk",
                table: "Massages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73e91fdc-0d71-4081-a984-8ddf0690b9c2", null, "User", "USER" },
                    { "f620f23e-0799-48a0-a5a4-a8fbeb4c0d24", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Massages_MassageId_fk",
                table: "Massages",
                column: "MassageId_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_Massages_MassageId_fk",
                table: "Massages",
                column: "MassageId_fk",
                principalTable: "Massages",
                principalColumn: "Id");
        }
    }
}
