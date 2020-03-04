using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    public partial class Database_Metrics_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DatabaseBackupMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DatabaseId = table.Column<Guid>(nullable: false),
                    Full = table.Column<DateTime>(nullable: true),
                    Differential = table.Column<DateTime>(nullable: true),
                    Transaction = table.Column<DateTime>(nullable: true),
                    RecoveryModel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseBackupMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseBackupMetrics_Databases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalTable: "Databases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseSpaceMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DatabaseId = table.Column<Guid>(nullable: false),
                    Space = table.Column<double>(nullable: false),
                    UnallocatedSpace = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseSpaceMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseSpaceMetrics_Databases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalTable: "Databases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemoryUsageMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ServerId = table.Column<Guid>(nullable: false),
                    PageLifetime = table.Column<int>(nullable: false),
                    RequestsCount = table.Column<int>(nullable: false),
                    PageReadsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryUsageMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemoryUsageMetrics_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessionMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ServerId = table.Column<Guid>(nullable: false),
                    UserLoginName = table.Column<string>(nullable: true)
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
                name: "IX_DatabaseBackupMetrics_DatabaseId",
                table: "DatabaseBackupMetrics",
                column: "DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseSpaceMetrics_DatabaseId",
                table: "DatabaseSpaceMetrics",
                column: "DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryUsageMetrics_ServerId",
                table: "MemoryUsageMetrics",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionMetrics_ServerId",
                table: "UserSessionMetrics",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatabaseBackupMetrics");

            migrationBuilder.DropTable(
                name: "DatabaseSpaceMetrics");

            migrationBuilder.DropTable(
                name: "MemoryUsageMetrics");

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
    }
}
