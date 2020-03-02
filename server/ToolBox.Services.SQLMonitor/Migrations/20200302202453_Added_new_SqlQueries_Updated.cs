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
                    { new Guid("5494a8a6-2405-4ce8-81a5-350e0bb20315"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6866), "List of Database names in a server", true, true, 1, "EXEC sp_databases", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6871) },
                    { new Guid("59cc09b9-f281-4a33-ad49-f20ae7a7da38"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6924), "Needs to be executed with keyword use [DATABASE_NAME]. Database space information", true, true, 3, "EXEC sp_spaceused @oneresultset = 1", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6925) },
                    { new Guid("86f9424d-87cf-46f7-8346-9c676766b30a"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6928), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6929) },
                    { new Guid("55b6f3a3-6729-424c-9c38-630d95bc71ea"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6931), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6932) },
                    { new Guid("0baa8e48-34c0-48e1-9e91-2514d0a17f50"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6937), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6938) },
                    { new Guid("01d70006-675f-43c3-9152-b98166780f49"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6934), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(6935) },
                    { new Guid("4cc67ee2-0d51-4eb7-9050-adc57fc06df3"), new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(4594), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 2, 20, 24, 52, 865, DateTimeKind.Utc).AddTicks(4621) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new DateTime(2020, 3, 2, 20, 24, 52, 866, DateTimeKind.Utc).AddTicks(3036), 4, true, true, new DateTime(2020, 3, 2, 20, 24, 52, 866, DateTimeKind.Local).AddTicks(3654), new DateTime(2020, 3, 2, 20, 24, 52, 866, DateTimeKind.Utc).AddTicks(3043) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreatedDate", "Description", "Host", "IsActive", "Login", "Name", "Password", "Port", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"), new DateTime(2020, 3, 2, 20, 24, 52, 862, DateTimeKind.Utc).AddTicks(4219), null, "localhost", true, "sa", "Sql monitor server", "Pass_w0rd12", 1465, new DateTime(2020, 3, 2, 20, 24, 52, 862, DateTimeKind.Utc).AddTicks(6119), new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6") });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "ServerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("f085547b-3081-4d08-acbf-fc5495fefd0b"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(5898), null, true, "SqlMonitor", new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(5923) },
                    { new Guid("27df32e3-4cad-4ebf-a207-90061560d155"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7863), null, true, "SqlMonitor", new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7868) },
                    { new Guid("c2a03d2c-73dc-4598-b20f-76c28bcb0cec"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7949), null, true, "modeldb", new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7950) },
                    { new Guid("e5792303-30e6-4995-9e2d-6b135a0b45a2"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7973), null, true, "msdb", new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7974) },
                    { new Guid("6846fe3e-8f43-4686-9995-23760462f37b"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7996), null, true, "tempdb", new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"), new DateTime(2020, 3, 2, 20, 24, 52, 864, DateTimeKind.Utc).AddTicks(7997) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleServer",
                columns: new[] { "ScheduleId", "ServerId" },
                values: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138") });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("5494a8a6-2405-4ce8-81a5-350e0bb20315") },
                    { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("59cc09b9-f281-4a33-ad49-f20ae7a7da38") },
                    { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("86f9424d-87cf-46f7-8346-9c676766b30a") },
                    { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("55b6f3a3-6729-424c-9c38-630d95bc71ea") },
                    { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("0baa8e48-34c0-48e1-9e91-2514d0a17f50") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("27df32e3-4cad-4ebf-a207-90061560d155"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("6846fe3e-8f43-4686-9995-23760462f37b"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("c2a03d2c-73dc-4598-b20f-76c28bcb0cec"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("e5792303-30e6-4995-9e2d-6b135a0b45a2"));

            migrationBuilder.DeleteData(
                table: "Databases",
                keyColumn: "Id",
                keyValue: new Guid("f085547b-3081-4d08-acbf-fc5495fefd0b"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("01d70006-675f-43c3-9152-b98166780f49"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("4cc67ee2-0d51-4eb7-9050-adc57fc06df3"));

            migrationBuilder.DeleteData(
                table: "ScheduleServer",
                keyColumns: new[] { "ScheduleId", "ServerId" },
                keyValues: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("0baa8e48-34c0-48e1-9e91-2514d0a17f50") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("5494a8a6-2405-4ce8-81a5-350e0bb20315") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("55b6f3a3-6729-424c-9c38-630d95bc71ea") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("59cc09b9-f281-4a33-ad49-f20ae7a7da38") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"), new Guid("86f9424d-87cf-46f7-8346-9c676766b30a") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0baa8e48-34c0-48e1-9e91-2514d0a17f50"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("5494a8a6-2405-4ce8-81a5-350e0bb20315"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("55b6f3a3-6729-424c-9c38-630d95bc71ea"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("59cc09b9-f281-4a33-ad49-f20ae7a7da38"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("86f9424d-87cf-46f7-8346-9c676766b30a"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("5445f44c-1055-4c51-b231-2be0ca64c2ab"));

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: new Guid("bf736e19-1aeb-4205-850e-b15bfd9c1138"));

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
