using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Database_Metrics_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSessionMetrics");

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("1b521ca5-3a72-4137-a985-951ec677a25b"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("3ea40930-5d39-47cb-aad3-c7f92bb7f9ff"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("fd27397d-84b1-4ed8-8377-a68ad6ff424f"));

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("1ca08f3a-08b0-42ba-85b1-c61ac5d4483e") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("b1dc0caa-de89-4b34-aa63-232f2eb773ec") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("e8d75324-bfee-41af-a076-c9f403e6bd84") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("ede94bb6-d9f7-4ac9-a664-cc9be36a76c4") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("1ca08f3a-08b0-42ba-85b1-c61ac5d4483e"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("b1dc0caa-de89-4b34-aa63-232f2eb773ec"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("e8d75324-bfee-41af-a076-c9f403e6bd84"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("ede94bb6-d9f7-4ac9-a664-cc9be36a76c4"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"));

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("46d73ff0-4214-4528-b24d-d56b598e6146"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6444), "Database space information", true, true, 3, "sp_spaceused", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6465) },
                    { new Guid("97cbefbc-a2da-4fe6-9dfe-c8c2e61318b4"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6526), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6528) },
                    { new Guid("0b41aa8c-0b16-4722-a814-5aa45bd2cf3c"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6530), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6531) },
                    { new Guid("cbe4545a-9641-4aa6-aff5-5a4475bdb2a3"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6556), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6557) },
                    { new Guid("1cc7230a-3bb3-4136-836e-3e0688faab71"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6533), "List of Database names in a server", true, true, 1, "sp_databases", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6534) },
                    { new Guid("ba443025-cf1d-4f2a-b790-f5f2908ee309"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6550), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6551) },
                    { new Guid("8d3e4ba6-99bc-476b-bd4b-181ae59b32be"), new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(2073), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(3857) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new DateTime(2020, 3, 4, 12, 12, 17, 272, DateTimeKind.Utc).AddTicks(5386), 4, true, true, new DateTime(2020, 3, 4, 12, 12, 17, 272, DateTimeKind.Local).AddTicks(6059), new DateTime(2020, 3, 4, 12, 12, 17, 272, DateTimeKind.Utc).AddTicks(5425) });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("46d73ff0-4214-4528-b24d-d56b598e6146") },
                    { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("97cbefbc-a2da-4fe6-9dfe-c8c2e61318b4") },
                    { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("0b41aa8c-0b16-4722-a814-5aa45bd2cf3c") },
                    { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("cbe4545a-9641-4aa6-aff5-5a4475bdb2a3") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("1cc7230a-3bb3-4136-836e-3e0688faab71"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("8d3e4ba6-99bc-476b-bd4b-181ae59b32be"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("ba443025-cf1d-4f2a-b790-f5f2908ee309"));

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("0b41aa8c-0b16-4722-a814-5aa45bd2cf3c") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("46d73ff0-4214-4528-b24d-d56b598e6146") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("97cbefbc-a2da-4fe6-9dfe-c8c2e61318b4") });

            migrationBuilder.DeleteData(
                table: "ScheduleSqlQuery",
                keyColumns: new[] { "ScheduleId", "SqlQueryId" },
                keyValues: new object[] { new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"), new Guid("cbe4545a-9641-4aa6-aff5-5a4475bdb2a3") });

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("0b41aa8c-0b16-4722-a814-5aa45bd2cf3c"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("46d73ff0-4214-4528-b24d-d56b598e6146"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("97cbefbc-a2da-4fe6-9dfe-c8c2e61318b4"));

            migrationBuilder.DeleteData(
                table: "SQLQueries",
                keyColumn: "Id",
                keyValue: new Guid("cbe4545a-9641-4aa6-aff5-5a4475bdb2a3"));

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"));

            migrationBuilder.CreateTable(
                name: "UserSessionMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessionMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessionMetrics_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SQLQueries",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsStoredProcedure", "Name", "Query", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("e8d75324-bfee-41af-a076-c9f403e6bd84"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7172), "Database space information", true, true, 3, "sp_spaceused", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7190) },
                    { new Guid("ede94bb6-d9f7-4ac9-a664-cc9be36a76c4"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7244), "Databases backup status", true, false, 2, @"SELECT d.name AS 'DATABASE_Name',
                                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                                          FROM MASTER.sys.databases d
                                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                                          FROM msdb.dbo.backupset
                                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                                          GROUP BY d.Name, d.recovery_model", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7247) },
                    { new Guid("b1dc0caa-de89-4b34-aa63-232f2eb773ec"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7249), "Finding users that are connected to the server", true, false, 4, @"SELECT login_name ,COUNT(session_id) AS session_count   
                                          FROM sys.dm_exec_sessions
                                          GROUP BY login_name; ", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7250) },
                    { new Guid("1ca08f3a-08b0-42ba-85b1-c61ac5d4483e"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7272), "Memory usage", true, false, 6, @"SELECT object_name, counter_name, cntr_value
                                            FROM sys.dm_os_performance_counters
                                            WHERE [object_name] LIKE '%Buffer Manager%'
                                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                                            'Page reads/sec')", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7273) },
                    { new Guid("fd27397d-84b1-4ed8-8377-a68ad6ff424f"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7252), "List of Database names in a server", true, true, 1, "sp_databases", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7253) },
                    { new Guid("3ea40930-5d39-47cb-aad3-c7f92bb7f9ff"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7255), "The most CPU consumed 20 queries", true, false, 5, @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                                        ", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(7256) },
                    { new Guid("1b521ca5-3a72-4137-a985-951ec677a25b"), new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(3146), "The name of a server", true, false, 0, "SELECT SERVERPROPERTY('Servername') as ServerName", new DateTime(2020, 3, 4, 10, 8, 32, 704, DateTimeKind.Utc).AddTicks(4821) }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Interval", "IsActive", "IsForServer", "LastInvokedDate", "UpdatedDate" },
                values: new object[] { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new DateTime(2020, 3, 4, 10, 8, 32, 706, DateTimeKind.Utc).AddTicks(8388), 4, true, true, new DateTime(2020, 3, 4, 10, 8, 32, 706, DateTimeKind.Local).AddTicks(9062), new DateTime(2020, 3, 4, 10, 8, 32, 706, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.InsertData(
                table: "ScheduleSqlQuery",
                columns: new[] { "ScheduleId", "SqlQueryId" },
                values: new object[,]
                {
                    { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("e8d75324-bfee-41af-a076-c9f403e6bd84") },
                    { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("ede94bb6-d9f7-4ac9-a664-cc9be36a76c4") },
                    { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("b1dc0caa-de89-4b34-aa63-232f2eb773ec") },
                    { new Guid("b4a73b7c-0374-4745-904b-3c4d30a47873"), new Guid("1ca08f3a-08b0-42ba-85b1-c61ac5d4483e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionMetrics_ServerId",
                table: "UserSessionMetrics",
                column: "ServerId");
        }
    }
}
