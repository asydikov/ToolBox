using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Commands;

namespace ToolBox.Services.SQLMonitor.Helpers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration((cfg) =>
            {
                cfg.AllowNullCollections = true;
                //   cfg.CreateMap<User, UserModel>().ForMember(x => x.Password, opt => opt.Ignore());

                cfg.CreateMap<SqlQuery, SqlQueryModel>();
                cfg.CreateMap<SqlQueryModel, SqlQuery>()
                .AfterMap((model, entity) => entity.Initialize());

                cfg.CreateMap<Server, ServerModel>();
                cfg.CreateMap<ServerModel, Server>()
                .AfterMap((model, entity) => entity.Initialize());

                cfg.CreateMap<Database, DatabaseModel>();
                cfg.CreateMap<DatabaseModel, Database>()
               .AfterMap((model, entity) => entity.Initialize());

                cfg.CreateMap<Schedule, ScheduleModel>();
                cfg.CreateMap<ScheduleModel, Schedule>()
                .AfterMap((model, entity) => entity.Initialize());


                cfg.CreateMap<ScheduleServer, ScheduleServerModel>();
                cfg.CreateMap<ScheduleServerModel, ScheduleServer>();


                cfg.CreateMap<ScheduleSqlQuery, ScheduleSqlQueryModel>();
                cfg.CreateMap<ScheduleSqlQueryModel, ScheduleSqlQuery>();


                cfg.CreateMap<DatabaseBackupMetrics, DatabaseBackupMetricsModel>();
                cfg.CreateMap<DatabaseBackupMetricsModel, DatabaseBackupMetrics>()
                 .AfterMap((model, entity) => entity.Initialize());

                cfg.CreateMap<DatabaseSpaceMetrics, DatabaseSpaceMetricsModel>();
                cfg.CreateMap<DatabaseSpaceMetricsModel, DatabaseSpaceMetrics>()
                 .AfterMap((model, entity) => entity.Initialize());

                cfg.CreateMap<MemoryUsageMetrics, MemoryUsageMetricsModel>();
                cfg.CreateMap<MemoryUsageMetricsModel, MemoryUsageMetrics>()
                 .AfterMap((model, entity) => entity.Initialize());




            });

            return config.CreateMapper();
        }
    }
}
