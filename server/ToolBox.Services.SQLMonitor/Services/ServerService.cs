﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RawRabbit;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Messages.Events.Notification;
using ToolBox.Services.SQLMonitor.Repositories;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class ServerService : ServiceBase<ServerModel, Server>, IServerService
    {
        private readonly IScheduleService _scheduleService;
        private readonly IBusClient _busClient;

        public ServerService(IRepositoryBase<Server> repository,
            IScheduleService scheduleService,
            IBusClient busClient,
        IMapper mapper) : base(repository, mapper)
        {
            _scheduleService = scheduleService;
            _busClient = busClient;
        }

        public async Task<Guid> AddServerWithSchedule(ServerModel model)
        {
            Server entity = _mapper.Map<Server>(model);

            var schedules = await _scheduleService.GetAllAsync();

            entity.ScheduleServers = new List<ScheduleServer>(){new ScheduleServer
            {
                ScheduleId = schedules.FirstOrDefault().Id,
                ServerId = entity.Id
            } };

          return await _repository.CreateAsync(entity);
         
        }

    }
}
