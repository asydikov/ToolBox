using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.Identity.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password" },
                values: new object[] { new Guid("ca362225-0562-470c-b712-5aea9a8e5f01"), new DateTime(2020, 2, 9, 18, 1, 16, 379, DateTimeKind.Utc).AddTicks(2430), "test@test.com", "Nick", "1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password" },
                values: new object[] { new Guid("c88e8569-f3db-4d7e-88f2-b7c6b25071d7"), new DateTime(2020, 2, 9, 18, 1, 16, 379, DateTimeKind.Utc).AddTicks(3200), "test@test.com", "John", "1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password" },
                values: new object[] { new Guid("48f2cace-05ae-45c6-af58-a4c8449ea67c"), new DateTime(2020, 2, 9, 18, 1, 16, 379, DateTimeKind.Utc).AddTicks(3350), "test@test.com", "Roe", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
