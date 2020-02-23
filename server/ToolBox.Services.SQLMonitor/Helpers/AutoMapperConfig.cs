﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Helpers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration((cfg) =>
            {
                //   cfg.CreateMap<User, UserModel>().ForMember(x => x.Password, opt => opt.Ignore());

                cfg.CreateMap<SQLQuery, SQLQueryModel>();
            

            });

            return config.CreateMapper();
        }
    }
}
