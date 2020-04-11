using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("e333c79a-385a-4b6b-a87e-d7b05e7d15ca"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4162), "List of Database names in a server", true, true, 1, "EXEC sp_databases", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4166) },
                    { new Guid("00eac203-337f-46bf-91c4-413aee272bb3"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4213), "Needs to be executed with keyword use [DATABASE_NAME]. Database space information", true, true, 3, "EXEC sp_spaceused @oneresultset = 1", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4214) },
                    { new Guid("22e55d5b-bc47-4090-adf0-fe9f72ce43fb"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4217), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4218) },
                    { new Guid("fe3dfbb6-cf90-48ce-8d04-4f21ec145e59"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4221), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4221) },
                    { new Guid("5a77003d-8ae7-475f-99bb-1e7a9c316116"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4227), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4228) },
                    { new Guid("1b03c565-4b9a-4809-bea8-c6e566263303"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4224), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(4224) },
                    { new Guid("0e0edf19-362e-4c0d-9059-41cb31c8c296"), new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(1968), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 2, 20, 52, 56, 617, DateTimeKind.Utc).AddTicks(1996) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new DateTime(2020, 3, 2, 20, 52, 56, 618, DateTimeKind.Utc).AddTicks(874), 4, true, true, new DateTime(2020, 3, 2, 20, 52, 56, 618, DateTimeKind.Local).AddTicks(1504), new DateTime(2020, 3, 2, 20, 52, 56, 618, DateTimeKind.Utc).AddTicks(881) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"), new DateTime(2020, 3, 2, 20, 52, 56, 614, DateTimeKind.Utc).AddTicks(1974), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 3, 2, 20, 52, 56, 614, DateTimeKind.Utc).AddTicks(3683), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1479e87e-edd1-4b30-aa3d-f00bcbec220d"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(2634), null, true, "SqlMonitor", new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(2661) },
                    { new Guid("187f4da4-c3de-4bca-ab1e-bab221dc5125"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(4872), null, true, "SqlMonitor", new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(4879) },
                    { new Guid("619e8b3a-c6ac-4b93-92e0-618056e863e9"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(5006), null, true, "modeldb", new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(5008) },
                    { new Guid("dd7f133d-aaaa-48dc-af32-6b832c3454ff"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(5034), null, true, "msdb", new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(5035) },
                    { new Guid("651460ef-9cff-4277-9284-fa4afad5c723"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(5055), null, true, "tempdb", new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"), new DateTime(2020, 3, 2, 20, 52, 56, 616, DateTimeKind.Utc).AddTicks(5056) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("00eac203-337f-46bf-91c4-413aee272bb3") },
                    { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("22e55d5b-bc47-4090-adf0-fe9f72ce43fb") },
                    { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("fe3dfbb6-cf90-48ce-8d04-4f21ec145e59") },
                    { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("5a77003d-8ae7-475f-99bb-1e7a9c316116") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("1479e87e-edd1-4b30-aa3d-f00bcbec220d"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("187f4da4-c3de-4bca-ab1e-bab221dc5125"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("619e8b3a-c6ac-4b93-92e0-618056e863e9"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("651460ef-9cff-4277-9284-fa4afad5c723"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("dd7f133d-aaaa-48dc-af32-6b832c3454ff"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0e0edf19-362e-4c0d-9059-41cb31c8c296"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("1b03c565-4b9a-4809-bea8-c6e566263303"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("e333c79a-385a-4b6b-a87e-d7b05e7d15ca"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("00eac203-337f-46bf-91c4-413aee272bb3") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("22e55d5b-bc47-4090-adf0-fe9f72ce43fb") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("5a77003d-8ae7-475f-99bb-1e7a9c316116") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"), new Guid("fe3dfbb6-cf90-48ce-8d04-4f21ec145e59") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("00eac203-337f-46bf-91c4-413aee272bb3"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("22e55d5b-bc47-4090-adf0-fe9f72ce43fb"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("5a77003d-8ae7-475f-99bb-1e7a9c316116"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("fe3dfbb6-cf90-48ce-8d04-4f21ec145e59"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("f703fac3-ccfa-4483-a5f6-4fb7bc6dafd8"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("3fed3c2a-e046-4760-aa62-654ef8a5e8f9"));

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
    }
}
