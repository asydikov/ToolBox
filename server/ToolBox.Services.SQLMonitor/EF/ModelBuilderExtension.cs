using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.EF
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var servers = AddServers(modelBuilder);
            var queries = AddQueries(modelBuilder);
            var schedules = AddSchedule(modelBuilder, servers, queries);
        }



        private static List<Server> AddServers(ModelBuilder modelBuilder)
        {
            var server = new Server
            {
                UserId = Guid.Parse("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"),
                Name = "Sql monitor server",
                Host = "localhost",
                Port = 1465,
                Login = "sa",
                Password = "Pass_w0rd12",
            };
            modelBuilder.Entity<Server>().HasData(server);

            var sqlMonitorDb = new Database
            {
                ServerId = server.Id,
                Name = "SqlMonitor"
            };
            modelBuilder.Entity<Database>().HasData(sqlMonitorDb);

            var masterDb = new Database
            {
                ServerId = server.Id,
                Name = "SqlMonitor"
            };
            modelBuilder.Entity<Database>().HasData(masterDb);

            var modelDb = new Database
            {
                ServerId = server.Id,
                Name = "modeldb"
            };
            modelBuilder.Entity<Database>().HasData(modelDb);

            var msDb = new Database
            {
                ServerId = server.Id,
                Name = "msdb"
            };
            modelBuilder.Entity<Database>().HasData(msDb);

            var tempDb = new Database
            {
                ServerId = server.Id,
                Name = "tempdb"
            };
            modelBuilder.Entity<Database>().HasData(tempDb);

            return new List<Server>() { server };
        }

        private static List<SqlQuery> AddQueries(ModelBuilder modelBuilder)
        {
            var serverName = new SqlQuery()
            {
                Name = SqlQueryNames.ServerName,
                Query = "SELECT SERVERPROPERTY('Servername') as ServerName",
                Description = "The name of a server",
                IsStoredProcedure = false
            };

            var query = new SqlQuery()
            {
                Name = SqlQueryNames.DatabaseNames,
                Query = "EXEC sp_databases",
                Description = "List of Database names in a server",
                IsStoredProcedure = true
            };

            var dbSpaceStatus = new SqlQuery()
            {
                Name = SqlQueryNames.DatabaseSpaceStatus,
                Query = "EXEC sp_spaceused @oneresultset = 1",
                Description = "Needs to be executed with keyword use [DATABASE_NAME]. Database space information",
                IsStoredProcedure = true
            };

            var dbBackupStatus = new SqlQuery()
            {
                Name = SqlQueryNames.DatabasesBackupStatus,
                Query = @"SELECT d.name AS 'DATABASE_Name',
                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                          FROM MASTER.sys.databases d
                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                          FROM msdb.dbo.backupset
                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                          GROUP BY d.Name, d.recovery_model",
                Description = "Databases backup status",
                IsStoredProcedure = false
            };

            var serverConnectedUsers = new SqlQuery()
            {
                Name = SqlQueryNames.ConnectedUsers,
                Query = @"SELECT login_name ,COUNT(session_id) AS session_count   
                          FROM sys.dm_exec_sessions
                          GROUP BY login_name; ",
                Description = "Finding users that are connected to the server",
                IsStoredProcedure = false
            };

            var twentyCpuConsumedQueries = new SqlQuery()
            {
                Name = SqlQueryNames.TwentyCPUConsumedQueries,
                Query = @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
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
                        ",
                Description = "The most CPU consumed 20 queries",
                IsStoredProcedure = false
            };


            var memoryUse = new SqlQuery()
            {
                Name = SqlQueryNames.MemoryUsage,
                Query = @"SELECT object_name, counter_name, cntr_value
                            FROM sys.dm_os_performance_counters
                            WHERE [object_name] LIKE '%Buffer Manager%'
                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                            'Page reads/sec')",
                Description = "Memory usage",
                IsStoredProcedure = false
            };


            
            modelBuilder.Entity<SqlQuery>().HasData(query);
            modelBuilder.Entity<SqlQuery>().HasData(dbSpaceStatus);
            modelBuilder.Entity<SqlQuery>().HasData(dbBackupStatus);
            modelBuilder.Entity<SqlQuery>().HasData(serverConnectedUsers);
            modelBuilder.Entity<SqlQuery>().HasData(memoryUse);
            modelBuilder.Entity<SqlQuery>().HasData(twentyCpuConsumedQueries);
            modelBuilder.Entity<SqlQuery>().HasData(serverName);
            return new List<SqlQuery>() { query, dbSpaceStatus, dbBackupStatus, serverConnectedUsers, memoryUse };
        }

        private static List<Schedule> AddSchedule(ModelBuilder modelBuilder, List<Server> servers, List<SqlQuery> sqlQueries)
        {

            var schedule = new Schedule()
            {
                Interval = 4,
                LastInvokedDate = DateTime.Now,
                IsForServer = true
            };
            modelBuilder.Entity<Schedule>().HasData(schedule);

            foreach (var sqlQuery in sqlQueries)
            {
                var scheduleSqlQuery = new ScheduleSqlQuery
                {
                    ScheduleId = schedule.Id,
                    SqlQueryId = sqlQuery.Id
                };
                modelBuilder.Entity<ScheduleSqlQuery>().HasData(scheduleSqlQuery);
            };


            foreach (var server in servers)
            {
                var scheduleServer = new ScheduleServer
                {
                    ScheduleId = schedule.Id,
                    ServerId = server.Id
                };
                modelBuilder.Entity<ScheduleServer>().HasData(scheduleServer);
            };

            return new List<Schedule>() { schedule };
        }

    }
}