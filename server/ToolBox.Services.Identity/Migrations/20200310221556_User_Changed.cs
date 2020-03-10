using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.Identity.Migrations
{
    public partial class User_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"),
                columns: new[] { "CreatedDate", "Name", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 3, 10, 22, 15, 56, 21, DateTimeKind.Utc).AddTicks(1005), "User", "AQAAAAEAACcQAAAAEH3HQ6kVA6Rq/NYCNTvVhomoMb4enitBbcoDmaFNzgiM2TRG5wByoDqXEV56vqSVEQ==", new DateTime(2020, 3, 10, 22, 15, 56, 21, DateTimeKind.Utc).AddTicks(2926) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"),
                columns: new[] { "CreatedDate", "Name", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 2, 26, 19, 54, 23, 604, DateTimeKind.Utc).AddTicks(5497), "Bart Simpson", "AQAAAAEAACcQAAAAEHjIzxd7dAVfsNLBMuIFlTE6RmTqHlKlyjTtHFUbX4q5WjYLBnuq2L2h3cZoyOKm+g==", new DateTime(2020, 2, 26, 19, 54, 23, 604, DateTimeKind.Utc).AddTicks(7217) });
        }
    }
}
