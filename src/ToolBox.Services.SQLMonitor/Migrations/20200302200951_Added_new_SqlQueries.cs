using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Added_new_SqlQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("56fd19f8-c997-4887-b6a1-5e9361e12f69"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(6008), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(6046) },
                    { new Guid("03e66313-3755-4190-a974-b053af085806"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8115), "List of Database names in a server", true, true, 1, "EXEC sp_databases", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8122) },
                    { new Guid("95c7f8e0-4c84-4f18-a4c2-5f7a77b00ad3"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8167), "Needs to be executed with keyword use [DATABASE_NAME]. Database space information", true, true, 3, "EXEC sp_spaceused @oneresultset = 1", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8168) },
                    { new Guid("78fedfb9-3e4e-4658-ab63-897663bc3559"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8170), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8171) },
                    { new Guid("37f8d10d-6d71-4968-9145-4ed49e68b653"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8174), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8175) },
                    { new Guid("0ee5ebee-a851-41a3-adbc-e7e7b4118cf8"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8177), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
                	                        	SUM(query_stats.total_worker_time) / SUM(query_stats.execution_count) AS 'Avg CPU Time',  
                	                        	MIN(query_stats.statement_text) AS 'Statement Text'  
                	                        FROM   
                	                        	(SELECT QS.*,   
                	                        	SUBSTRING(ST.text, (QS.statement_start_offset/2) + 1,  
                	                        	((CASE statement_end_offset   
                	                        		WHEN -1 THEN DATALENGTH(ST.text)  
                	                        		ELSE QS.statement_end_offset END   
                	                        			- QS.statement_start_offset)/2) + 1) AS statement_text  
                	                        	 FROM sys.dm_exec_query_stats AS QS  
                	                        	 CROSS APPLY sys.dm_exec_sql_text(QS.sql_handle) as ST) as query_stats  
                	                        GROUP BY query_stats.query_hash  
                	                        ORDER BY 2 DESC;  
                                        ", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8178) },
                    { new Guid("27ec8cb9-71a2-44c7-8189-1c1f94b74e2f"), new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8188), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 2, 20, 9, 50, 877, DateTimeKind.Utc).AddTicks(8189) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new DateTime(2020, 3, 2, 20, 9, 50, 878, DateTimeKind.Utc).AddTicks(4264), 5, true, true, new DateTime(2020, 3, 2, 20, 9, 50, 878, DateTimeKind.Local).AddTicks(4889), new DateTime(2020, 3, 2, 20, 9, 50, 878, DateTimeKind.Utc).AddTicks(4271) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"), new DateTime(2020, 3, 2, 20, 9, 50, 874, DateTimeKind.Utc).AddTicks(6850), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 3, 2, 20, 9, 50, 874, DateTimeKind.Utc).AddTicks(8577), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("f1d30005-182e-4274-8607-55dd7b3c4ed8"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(5639), null, true, "SqlMonitor", new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(5670) },
                    { new Guid("71801f2d-223b-4efe-adf9-2e7b59a80f80"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8585), null, true, "SqlMonitor", new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8593) },
                    { new Guid("3fb03345-59c3-4aca-adc7-19c476aca7c1"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8675), null, true, "modeldb", new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8676) },
                    { new Guid("93b86968-9da3-42ff-b1b7-85c91c6bb990"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8719), null, true, "msdb", new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8721) },
                    { new Guid("691dfcce-dec5-40c3-8d8b-6d3250a2121d"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8744), null, true, "tempdb", new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"), new DateTime(2020, 3, 2, 20, 9, 50, 876, DateTimeKind.Utc).AddTicks(8745) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("56fd19f8-c997-4887-b6a1-5e9361e12f69") },
                    { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("03e66313-3755-4190-a974-b053af085806") },
                    { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("95c7f8e0-4c84-4f18-a4c2-5f7a77b00ad3") },
                    { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("78fedfb9-3e4e-4658-ab63-897663bc3559") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("3fb03345-59c3-4aca-adc7-19c476aca7c1"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("691dfcce-dec5-40c3-8d8b-6d3250a2121d"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("71801f2d-223b-4efe-adf9-2e7b59a80f80"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("93b86968-9da3-42ff-b1b7-85c91c6bb990"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("f1d30005-182e-4274-8607-55dd7b3c4ed8"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0ee5ebee-a851-41a3-adbc-e7e7b4118cf8"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("27ec8cb9-71a2-44c7-8189-1c1f94b74e2f"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("37f8d10d-6d71-4968-9145-4ed49e68b653"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("03e66313-3755-4190-a974-b053af085806") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("56fd19f8-c997-4887-b6a1-5e9361e12f69") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("78fedfb9-3e4e-4658-ab63-897663bc3559") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"), new Guid("95c7f8e0-4c84-4f18-a4c2-5f7a77b00ad3") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("03e66313-3755-4190-a974-b053af085806"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("56fd19f8-c997-4887-b6a1-5e9361e12f69"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("78fedfb9-3e4e-4658-ab63-897663bc3559"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("95c7f8e0-4c84-4f18-a4c2-5f7a77b00ad3"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("75db5b1d-a996-4523-90a9-33ac84eb7126"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("59a75aa0-c958-4604-aa7b-3ffa21686c94"));

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
    }
}
