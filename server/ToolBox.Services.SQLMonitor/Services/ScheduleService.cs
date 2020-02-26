﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Repositories;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class ScheduleService : ServiceBase<ScheduleModel, Schedule>, IScheduleService
    {
        public ScheduleService(IRepositoryBase<Schedule> repository, IMapper mapper) : base(repository, mapper)
        {
             
        }

      
    }
}
