using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Added_new_SqlQueries_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("e30573c0-c2fb-4a12-b79b-8891f30f41e3"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7677), "List of Database names in a server", true, true, 1, "EXEC sp_databases", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7683) },
                    { new Guid("5ce58f94-3d76-4218-9968-a08eedbe4794"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7739), "Needs to be executed with keyword use [DATABASE_NAME]. Database space information", true, true, 3, "EXEC sp_spaceused @oneresultset = 1", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7740) },
                    { new Guid("1c1ea729-9210-43bb-85f4-854005bf107a"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7743), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7745) },
                    { new Guid("27604b4f-19e4-4ff6-a8de-ba42ff5aab5e"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7747), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7748) },
                    { new Guid("f590683f-c347-4bf5-ab73-c8911c7469db"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7754), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7755) },
                    { new Guid("d6e7476d-3bce-4fa5-afcd-88965a976096"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7751), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7752) },
                    { new Guid("d1f1ff22-2f9f-409d-b229-a967e67259a4"), new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(5586), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(5614) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new DateTime(2020, 3, 2, 20, 42, 5, 816, DateTimeKind.Utc).AddTicks(4004), 4, true, true, new DateTime(2020, 3, 2, 20, 42, 5, 816, DateTimeKind.Local).AddTicks(4672), new DateTime(2020, 3, 2, 20, 42, 5, 816, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"), new DateTime(2020, 3, 2, 20, 42, 5, 812, DateTimeKind.Utc).AddTicks(2138), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 3, 2, 20, 42, 5, 812, DateTimeKind.Utc).AddTicks(3814), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a6a8bf00-83e9-4541-ba85-a616c8166122"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(6747), null, true, "SqlMonitor", new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(6771) },
                    { new Guid("b1843653-ccf3-457f-bcb3-6040bf2f0fbe"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8875), null, true, "SqlMonitor", new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8882) },
                    { new Guid("d961c3a4-c027-4c28-8afc-449d55472806"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8962), null, true, "modeldb", new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8963) },
                    { new Guid("9915d74b-a3ba-4e55-9446-edd2c493d134"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8987), null, true, "msdb", new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8988) },
                    { new Guid("b63d70da-5ae2-4b9a-bc31-5edb2cc7b3ab"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(9009), null, true, "tempdb", new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"), new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(9010) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("e30573c0-c2fb-4a12-b79b-8891f30f41e3") },
                    { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("5ce58f94-3d76-4218-9968-a08eedbe4794") },
                    { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("1c1ea729-9210-43bb-85f4-854005bf107a") },
                    { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("27604b4f-19e4-4ff6-a8de-ba42ff5aab5e") },
                    { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("f590683f-c347-4bf5-ab73-c8911c7469db") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("9915d74b-a3ba-4e55-9446-edd2c493d134"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("a6a8bf00-83e9-4541-ba85-a616c8166122"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("b1843653-ccf3-457f-bcb3-6040bf2f0fbe"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("b63d70da-5ae2-4b9a-bc31-5edb2cc7b3ab"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("d961c3a4-c027-4c28-8afc-449d55472806"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("d1f1ff22-2f9f-409d-b229-a967e67259a4"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("d6e7476d-3bce-4fa5-afcd-88965a976096"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("1c1ea729-9210-43bb-85f4-854005bf107a") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("27604b4f-19e4-4ff6-a8de-ba42ff5aab5e") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("5ce58f94-3d76-4218-9968-a08eedbe4794") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("e30573c0-c2fb-4a12-b79b-8891f30f41e3") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"), new Guid("f590683f-c347-4bf5-ab73-c8911c7469db") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("1c1ea729-9210-43bb-85f4-854005bf107a"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("27604b4f-19e4-4ff6-a8de-ba42ff5aab5e"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("5ce58f94-3d76-4218-9968-a08eedbe4794"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("e30573c0-c2fb-4a12-b79b-8891f30f41e3"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("f590683f-c347-4bf5-ab73-c8911c7469db"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"));

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
    }
}
