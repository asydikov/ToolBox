using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Servers_And_Databases_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("84c89c27-3037-42f0-8f5d-0b0f8beceb7c"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6022), "Database space information", true, true, 3, "sp_spaceused", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6041) },
                    { new Guid("1971141a-c5cc-4feb-848e-ee0b54ac316c"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6101), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6102) },
                    { new Guid("8d1226ed-8ee8-4300-acaf-fc262590d2ff"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6106), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6107) },
                    { new Guid("9f008b81-3189-4354-bd32-97df11282de2"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6116), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6117) },
                    { new Guid("0272a9d7-bc75-4a97-9ffb-b0f556898f16"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6109), "List of Database names in a server", true, true, 1, "sp_databases", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6110) },
                    { new Guid("584ba790-3b8b-469a-ab23-4481855d3e73"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6113), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(6114) },
                    { new Guid("0491bb83-b3c7-4b1a-8582-5ee49e4e5228"), new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(1736), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 4, 1, 12, 32, 205, DateTimeKind.Utc).AddTicks(3517) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new DateTime(2020, 3, 4, 1, 12, 32, 207, DateTimeKind.Utc).AddTicks(8429), 4, true, true, new DateTime(2020, 3, 4, 1, 12, 32, 207, DateTimeKind.Local).AddTicks(9183), new DateTime(2020, 3, 4, 1, 12, 32, 207, DateTimeKind.Utc).AddTicks(8481) });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("84c89c27-3037-42f0-8f5d-0b0f8beceb7c") },
                    { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("1971141a-c5cc-4feb-848e-ee0b54ac316c") },
                    { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("8d1226ed-8ee8-4300-acaf-fc262590d2ff") },
                    { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("9f008b81-3189-4354-bd32-97df11282de2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0272a9d7-bc75-4a97-9ffb-b0f556898f16"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0491bb83-b3c7-4b1a-8582-5ee49e4e5228"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("584ba790-3b8b-469a-ab23-4481855d3e73"));

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("1971141a-c5cc-4feb-848e-ee0b54ac316c") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("84c89c27-3037-42f0-8f5d-0b0f8beceb7c") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("8d1226ed-8ee8-4300-acaf-fc262590d2ff") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"), new Guid("9f008b81-3189-4354-bd32-97df11282de2") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("1971141a-c5cc-4feb-848e-ee0b54ac316c"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("84c89c27-3037-42f0-8f5d-0b0f8beceb7c"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("8d1226ed-8ee8-4300-acaf-fc262590d2ff"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("9f008b81-3189-4354-bd32-97df11282de2"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("e68a93e5-3455-4533-ad5a-3f6a28a1be6f"));

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
    }
}
