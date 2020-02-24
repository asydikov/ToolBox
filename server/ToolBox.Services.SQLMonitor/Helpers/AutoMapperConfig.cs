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
                //   cfg.CreateMap<User, UserModel>().ForMember(x => x.Password, opt => opt.Ignore());

                cfg.CreateMap<SqlQuery, SqlQueryModel>();
                cfg.CreateMap<SqlQueryModel, SqlQuery>()
                .AfterMap((model, entity) => entity.Initialize());
                cfg.CreateMap<ServerModel, Server>()
                .AfterMap((model, entity) => entity.Initialize());
                cfg.CreateMap<DatabaseModel, Database>()
               .AfterMap((model, entity) => entity.Initialize());


                cfg.CreateMap<ServerCommand, DatabaseModel>();


            });

            return config.CreateMapper();
        }
    }
}
