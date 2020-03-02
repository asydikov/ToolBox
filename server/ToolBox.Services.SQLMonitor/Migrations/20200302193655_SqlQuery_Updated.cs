using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class SqlQuery_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "SQLQueries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("cc987ef0-191a-44ca-a6bf-f0d9913638e0"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(9665), "The name of a server", true, false, 0, "select SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(9691) },
                    { new Guid("c3af5cb3-f987-4c9e-a9a8-7a8dab22c9ce"), new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(1746), "List of Database names in a server", true, true, 1, "EXEC sp_databases", new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(1751) },
                    { new Guid("66136544-7582-481a-8bd9-7b99d8a8865f"), new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(1842), "Needs to be executed with keyword use [DATABASE_NAME]. Database space information", true, true, 3, "EXEC sp_spaceused @oneresultset = 1", new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(1844) },
                    { new Guid("3f5d446b-4a69-40e9-9432-9ae20d0c74cf"), new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(1847), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(1848) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(7948), 5, true, true, new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Local).AddTicks(8572), new DateTime(2020, 3, 2, 19, 36, 54, 902, DateTimeKind.Utc).AddTicks(7955) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"), new DateTime(2020, 3, 2, 19, 36, 54, 899, DateTimeKind.Utc).AddTicks(3796), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 3, 2, 19, 36, 54, 899, DateTimeKind.Utc).AddTicks(5527), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ada3e863-3582-4b1a-94cc-178a09dc7703"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(2667), null, true, "SqlMonitor", new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(2697) },
                    { new Guid("09b7f067-7c85-44dc-adf7-358d9ff33192"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5016), null, true, "SqlMonitor", new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5022) },
                    { new Guid("dcd9b218-fb1d-48a1-b850-a172c48c40f4"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5103), null, true, "modeldb", new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5104) },
                    { new Guid("c99fe396-b733-4dba-921f-8ac9c7dcb922"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5144), null, true, "msdb", new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5146) },
                    { new Guid("f6894cd4-7c63-4d6c-b05b-7b817b50ebe8"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5167), null, true, "tempdb", new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"), new DateTime(2020, 3, 2, 19, 36, 54, 901, DateTimeKind.Utc).AddTicks(5168) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("cc987ef0-191a-44ca-a6bf-f0d9913638e0") },
                    { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("c3af5cb3-f987-4c9e-a9a8-7a8dab22c9ce") },
                    { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("66136544-7582-481a-8bd9-7b99d8a8865f") },
                    { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("3f5d446b-4a69-40e9-9432-9ae20d0c74cf") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("09b7f067-7c85-44dc-adf7-358d9ff33192"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("ada3e863-3582-4b1a-94cc-178a09dc7703"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("c99fe396-b733-4dba-921f-8ac9c7dcb922"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("dcd9b218-fb1d-48a1-b850-a172c48c40f4"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("f6894cd4-7c63-4d6c-b05b-7b817b50ebe8"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("3f5d446b-4a69-40e9-9432-9ae20d0c74cf") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("66136544-7582-481a-8bd9-7b99d8a8865f") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("c3af5cb3-f987-4c9e-a9a8-7a8dab22c9ce") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"), new Guid("cc987ef0-191a-44ca-a6bf-f0d9913638e0") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("3f5d446b-4a69-40e9-9432-9ae20d0c74cf"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("66136544-7582-481a-8bd9-7b99d8a8865f"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("c3af5cb3-f987-4c9e-a9a8-7a8dab22c9ce"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("cc987ef0-191a-44ca-a6bf-f0d9913638e0"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("1579e6f3-24bd-4f60-9a93-de89ca91a5ce"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("773e13be-10e3-4dfb-9c40-01e34e78d759"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SQLQueries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

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
    }
}
