using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Schedule_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Databases",
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

            migrationBuilder.CreateTable(
                name: "ScheduleSqlQuery",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(nullable: false),
                    SqlQueryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSqlQuery", x => new { x.ScheduleId, x.SqlQueryId });
                    table.ForeignKey(
                        name: "FK_ScheduleSqlQuery_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleSqlQuery_SQLQueries_SqlQueryId",
                        column: x => x.SqlQueryId,
                        principalTable: "SQLQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "UpdatedDate" },
                values: new object[] { new Guid("9edf1682-53af-495b-b99b-ed2513e7a3db"), new DateTime(2020, 2, 25, 23, 31, 10, 86, DateTimeKind.Utc).AddTicks(1117), "List of Database names in a server", true, true, "sp_databases", "sp_databases", new DateTime(2020, 2, 25, 23, 31, 10, 86, DateTimeKind.Utc).AddTicks(1143) });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("bbc5bcaf-845d-4f90-a3f4-009520687a60"), new DateTime(2020, 2, 25, 23, 31, 10, 86, DateTimeKind.Utc).AddTicks(9217), 5, true, true, new DateTime(2020, 2, 25, 23, 31, 10, 86, DateTimeKind.Local).AddTicks(9830), new DateTime(2020, 2, 25, 23, 31, 10, 86, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"), new DateTime(2020, 2, 25, 23, 31, 10, 83, DateTimeKind.Utc).AddTicks(5049), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 2, 25, 23, 31, 10, 83, DateTimeKind.Utc).AddTicks(6728), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("67a65524-de22-45e7-ab19-6ea6d908084a"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(5844), null, true, "SqlMonitor", new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(5863) },
                    { new Guid("7c621003-29b4-41c0-bf61-321ce440c324"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(7825), null, true, "SqlMonitor", new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(7831) },
                    { new Guid("01de20a8-bbec-4230-8a94-1cec2bbe3e5c"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(7908), null, true, "modeldb", new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(7909) },
                    { new Guid("f59183f2-aa8f-47e9-9623-147193064b72"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(7934), null, true, "msdb", new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(7935) },
                    { new Guid("a26e1e2d-3372-44fe-acbc-ae3d7ab57a04"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(8005), null, true, "tempdb", new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"), new DateTime(2020, 2, 25, 23, 31, 10, 85, DateTimeKind.Utc).AddTicks(8006) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("bbc5bcaf-845d-4f90-a3f4-009520687a60"), new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[] { new Guid("bbc5bcaf-845d-4f90-a3f4-009520687a60"), new Guid("9edf1682-53af-495b-b99b-ed2513e7a3db") });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleServer_ServerId",
                table: "ScheduleServer",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSqlQuery_SqlQueryId",
                table: "ScheduleSqlQuery",
                column: "SqlQueryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleServer");

            migrationBuilder.DropTable(
                name: "ScheduleSqlQuery");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("01de20a8-bbec-4230-8a94-1cec2bbe3e5c"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("67a65524-de22-45e7-ab19-6ea6d908084a"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("7c621003-29b4-41c0-bf61-321ce440c324"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("a26e1e2d-3372-44fe-acbc-ae3d7ab57a04"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("f59183f2-aa8f-47e9-9623-147193064b72"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("9edf1682-53af-495b-b99b-ed2513e7a3db"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Databases");
        }
    }
}
