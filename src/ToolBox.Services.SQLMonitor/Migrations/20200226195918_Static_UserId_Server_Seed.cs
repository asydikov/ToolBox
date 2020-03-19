using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Static_UserId_Server_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("bbc5bcaf-845d-4f90-a3f4-009520687a60"), new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("bbc5bcaf-845d-4f90-a3f4-009520687a60"), new Guid("9edf1682-53af-495b-b99b-ed2513e7a3db") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("9edf1682-53af-495b-b99b-ed2513e7a3db"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("bbc5bcaf-845d-4f90-a3f4-009520687a60"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("f8a082a8-c274-4872-a5e1-aa6bf6ac2999"));

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "UpdatedDate" },
                values: new object[] { new Guid("a69a2b43-3abe-450f-a354-5456a93e4649"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(4756), "List of Database names in a server", true, true, "sp_databases", "sp_databases", new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("4be3e41e-f392-4e30-bf54-a01acc2de755"), new DateTime(2020, 2, 26, 19, 59, 18, 300, DateTimeKind.Utc).AddTicks(2752), 5, true, true, new DateTime(2020, 2, 26, 19, 59, 18, 300, DateTimeKind.Local).AddTicks(3357), new DateTime(2020, 2, 26, 19, 59, 18, 300, DateTimeKind.Utc).AddTicks(2759) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"), new DateTime(2020, 2, 26, 19, 59, 18, 297, DateTimeKind.Utc).AddTicks(501), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 2, 26, 19, 59, 18, 297, DateTimeKind.Utc).AddTicks(2161), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("32a547e4-5a2e-4725-b98b-dbe380d49d3f"), new DateTime(2020, 2, 26, 19, 59, 18, 298, DateTimeKind.Utc).AddTicks(9506), null, true, "SqlMonitor", new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"), new DateTime(2020, 2, 26, 19, 59, 18, 298, DateTimeKind.Utc).AddTicks(9526) },
                    { new Guid("af1e4531-093b-488d-99ce-9aec3f61910e"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1474), null, true, "SqlMonitor", new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1480) },
                    { new Guid("df88759e-522b-494a-9c75-16193966c094"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1566), null, true, "modeldb", new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1567) },
                    { new Guid("f1d80e65-466a-4703-bad3-6bf685317ea0"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1608), null, true, "msdb", new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1609) },
                    { new Guid("642a6fd2-9f8b-460b-914a-6d35da2789f4"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1632), null, true, "tempdb", new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"), new DateTime(2020, 2, 26, 19, 59, 18, 299, DateTimeKind.Utc).AddTicks(1633) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("4be3e41e-f392-4e30-bf54-a01acc2de755"), new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[] { new Guid("4be3e41e-f392-4e30-bf54-a01acc2de755"), new Guid("a69a2b43-3abe-450f-a354-5456a93e4649") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("32a547e4-5a2e-4725-b98b-dbe380d49d3f"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("642a6fd2-9f8b-460b-914a-6d35da2789f4"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("af1e4531-093b-488d-99ce-9aec3f61910e"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("df88759e-522b-494a-9c75-16193966c094"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("f1d80e65-466a-4703-bad3-6bf685317ea0"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("4be3e41e-f392-4e30-bf54-a01acc2de755"), new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("4be3e41e-f392-4e30-bf54-a01acc2de755"), new Guid("a69a2b43-3abe-450f-a354-5456a93e4649") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("a69a2b43-3abe-450f-a354-5456a93e4649"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("4be3e41e-f392-4e30-bf54-a01acc2de755"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("db49da15-c17a-43a9-9ed7-08b6693f7865"));

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
        }
    }
}
