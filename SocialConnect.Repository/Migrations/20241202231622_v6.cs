using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialConnect.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ce909e5-e938-4f0b-9098-d49bba6890dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90a9aaf2-b3c1-41eb-9d24-b32aec1fc812");

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "React",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "React",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "566f7a24-8980-4195-b43f-2e55a00975bd", null, "Admin", null },
                    { "e74713b6-46e6-4295-bd2a-25f41221d6ef", null, "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_React_CommentId",
                table: "React",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_React_PostId",
                table: "React",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_React_Comments_CommentId",
                table: "React",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_React_Posts_PostId",
                table: "React",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_React_Comments_CommentId",
                table: "React");

            migrationBuilder.DropForeignKey(
                name: "FK_React_Posts_PostId",
                table: "React");

            migrationBuilder.DropIndex(
                name: "IX_React_CommentId",
                table: "React");

            migrationBuilder.DropIndex(
                name: "IX_React_PostId",
                table: "React");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "566f7a24-8980-4195-b43f-2e55a00975bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74713b6-46e6-4295-bd2a-25f41221d6ef");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "React");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "React");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ce909e5-e938-4f0b-9098-d49bba6890dc", null, "Admin", null },
                    { "90a9aaf2-b3c1-41eb-9d24-b32aec1fc812", null, "User", null }
                });
        }
    }
}
