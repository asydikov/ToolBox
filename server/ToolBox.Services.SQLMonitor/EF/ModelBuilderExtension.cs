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

            var queries = AddQueries(modelBuilder);
            var schedules = AddSchedule(modelBuilder, queries);
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

            var dbSpaceStatus = new SqlQuery()
            {
                Name = SqlQueryNames.DatabaseSpaceStatus,
                Query = "sp_spaceused",
                Description = "Database space information",
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

            var databaseNames = new SqlQuery()
            {
                Name = SqlQueryNames.DatabaseNames,
                Query = "sp_databases",
                Description = "List of Database names in a server",
                IsStoredProcedure = true
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


            var memoryUsage = new SqlQuery()
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
            
            modelBuilder.Entity<SqlQuery>().HasData(dbSpaceStatus);
            modelBuilder.Entity<SqlQuery>().HasData(dbBackupStatus);
            modelBuilder.Entity<SqlQuery>().HasData(serverConnectedUsers);
            modelBuilder.Entity<SqlQuery>().HasData(memoryUsage);
            modelBuilder.Entity<SqlQuery>().HasData(databaseNames);
            modelBuilder.Entity<SqlQuery>().HasData(twentyCpuConsumedQueries);
            modelBuilder.Entity<SqlQuery>().HasData(serverName);
            return new List<SqlQuery>() { dbSpaceStatus, dbBackupStatus, serverConnectedUsers, memoryUsage };
        }

        private static List<Schedule> AddSchedule(ModelBuilder modelBuilder, List<SqlQuery> sqlQueries)
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

            return new List<Schedule>() { schedule };
        }

    }
}