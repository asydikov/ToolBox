using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class DatabasesList_Query_Removed_SqlQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("21102ac6-1c4b-4aad-8384-ed9da76013c8"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5378), "List of Database names in a server", true, true, 1, "EXEC sp_databases", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5383) },
                    { new Guid("6b981c8e-5699-4392-bf08-839e67c5bab0"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5432), "Needs to be executed with keyword use [DATABASE_NAME]. Database space information", true, true, 3, "EXEC sp_spaceused @oneresultset = 1", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5434) },
                    { new Guid("2f5b1a14-6a42-497d-abfb-4b5ab5d44162"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5436), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5437) },
                    { new Guid("9e63cb85-82b7-4632-a3c5-274482536683"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5439), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5440) },
                    { new Guid("600e16b6-d7ed-417f-9d8c-8fda41a3ae92"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5454), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5454) },
                    { new Guid("3df485ec-0023-499a-88ce-3c575f2fefaa"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5451), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(5451) },
                    { new Guid("8b16f156-01d0-4c8c-a456-09982472b216"), new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(3248), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 2, 20, 45, 33, 770, DateTimeKind.Utc).AddTicks(3275) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new DateTime(2020, 3, 2, 20, 45, 33, 771, DateTimeKind.Utc).AddTicks(1792), 4, true, true, new DateTime(2020, 3, 2, 20, 45, 33, 771, DateTimeKind.Local).AddTicks(2431), new DateTime(2020, 3, 2, 20, 45, 33, 771, DateTimeKind.Utc).AddTicks(1799) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"), new DateTime(2020, 3, 2, 20, 45, 33, 767, DateTimeKind.Utc).AddTicks(3557), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 3, 2, 20, 45, 33, 767, DateTimeKind.Utc).AddTicks(5286), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2403d389-24ff-46bc-b56a-a1478b3df290"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(3637), null, true, "SqlMonitor", new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(3664) },
                    { new Guid("2d340c1b-5632-4139-9ef0-ffb00d5d1b07"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6473), null, true, "SqlMonitor", new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6479) },
                    { new Guid("c7bd44b1-7b3c-4c2f-977d-d953a6b0a218"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6573), null, true, "modeldb", new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6574) },
                    { new Guid("2019191b-1483-4d00-bcd9-2676b146dfa2"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6600), null, true, "msdb", new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6602) },
                    { new Guid("9b776696-7130-411c-ae29-19ff05851d1e"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6625), null, true, "tempdb", new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"), new DateTime(2020, 3, 2, 20, 45, 33, 769, DateTimeKind.Utc).AddTicks(6626) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("8158adeb-d343-409e-8b9c-446edb50d62f") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("6b981c8e-5699-4392-bf08-839e67c5bab0") },
                    { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("2f5b1a14-6a42-497d-abfb-4b5ab5d44162") },
                    { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("9e63cb85-82b7-4632-a3c5-274482536683") },
                    { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("600e16b6-d7ed-417f-9d8c-8fda41a3ae92") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("2019191b-1483-4d00-bcd9-2676b146dfa2"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("2403d389-24ff-46bc-b56a-a1478b3df290"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("2d340c1b-5632-4139-9ef0-ffb00d5d1b07"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("9b776696-7130-411c-ae29-19ff05851d1e"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("c7bd44b1-7b3c-4c2f-977d-d953a6b0a218"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("21102ac6-1c4b-4aad-8384-ed9da76013c8"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("3df485ec-0023-499a-88ce-3c575f2fefaa"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("8b16f156-01d0-4c8c-a456-09982472b216"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("8158adeb-d343-409e-8b9c-446edb50d62f") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("2f5b1a14-6a42-497d-abfb-4b5ab5d44162") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("600e16b6-d7ed-417f-9d8c-8fda41a3ae92") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("6b981c8e-5699-4392-bf08-839e67c5bab0") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"), new Guid("9e63cb85-82b7-4632-a3c5-274482536683") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("2f5b1a14-6a42-497d-abfb-4b5ab5d44162"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("600e16b6-d7ed-417f-9d8c-8fda41a3ae92"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("6b981c8e-5699-4392-bf08-839e67c5bab0"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("9e63cb85-82b7-4632-a3c5-274482536683"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("b7ce20a2-813b-40ab-89e0-8159f2651a2e"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("8158adeb-d343-409e-8b9c-446edb50d62f"));

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
    }
}
