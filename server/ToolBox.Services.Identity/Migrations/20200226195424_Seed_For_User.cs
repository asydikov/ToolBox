using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.Identity.Migrations
{
    public partial class Seed_For_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "Name", "Password", "RefreshTokenId", "UpdatedDate" },
                values: new object[] { new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"), new DateTime(2020, 2, 26, 19, 54, 23, 604, DateTimeKind.Utc).AddTicks(5497), "test@test.com", true, "Bart Simpson", "AQAAAAEAACcQAAAAEHjIzxd7dAVfsNLBMuIFlTE6RmTqHlKlyjTtHFUbX4q5WjYLBnuq2L2h3cZoyOKm+g==", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2020, 2, 26, 19, 54, 23, 604, DateTimeKind.Utc).AddTicks(7217) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"));
        }
    }
}
