using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var query = new SqlQuery()
            {
                Name = "sp_databases",
                Query = "sp_databases",
                Description = "List of Database names in a server",
                IsStoredProcedure = true
            };

            modelBuilder.Entity<SqlQuery>().HasData(query);
            return new List<SqlQuery>() { query };
        }

        private static List<Schedule> AddSchedule(ModelBuilder modelBuilder, List<Server> servers, List<SqlQuery> sqlQueries)
        {

            var schedule = new Schedule()
            {
                Interval = 5,
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