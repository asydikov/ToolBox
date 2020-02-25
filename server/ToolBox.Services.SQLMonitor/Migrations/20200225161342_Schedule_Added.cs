using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Schedule_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "SQLQueries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    LastInvokedDate = table.Column<DateTime>(nullable: false),
                    IsForServer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDatabase",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(nullable: false),
                    DatabaseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDatabase", x => new { x.ScheduleId, x.DatabaseId });
                    table.ForeignKey(
                        name: "FK_ScheduleDatabase_Databases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalTable: "Databases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleDatabase_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleServer",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(nullable: false),
                    ServerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleServer", x => new { x.ScheduleId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_ScheduleServer_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleServer_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "ScheduleId", "UpdatedDate" },
                values: new object[] { new Guid("0eaabcad-bea5-4de2-ac61-bd8ed071bf3f"), new DateTime(2020, 2, 25, 16, 13, 41, 602, DateTimeKind.Utc).AddTicks(6111), "List of Database names in a server", true, true, "sp_databases", "sp_databases", null, new DateTime(2020, 2, 25, 16, 13, 41, 602, DateTimeKind.Utc).AddTicks(7849) });

            migrationBuilder.CreateIndex(
                name: "IX_SQLQueries_ScheduleId",
                table: "SQLQueries",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDatabase_DatabaseId",
                table: "ScheduleDatabase",
                column: "DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleServer_ServerId",
                table: "ScheduleServer",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SQLQueries_Schedules_ScheduleId",
                table: "SQLQueries",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SQLQueries_Schedules_ScheduleId",
                table: "SQLQueries");

            migrationBuilder.DropTable(
                name: "ScheduleDatabase");

            migrationBuilder.DropTable(
                name: "ScheduleServer");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_SQLQueries_ScheduleId",
                table: "SQLQueries");

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0eaabcad-bea5-4de2-ac61-bd8ed071bf3f"));

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "SQLQueries");
        }
    }
}
