using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IDataProtector _protector;

        public ServerService(IRepositoryBase<Server> repository,
            IScheduleService scheduleService,
            IDataProtectionProvider dataProtector,
            IMapper mapper) : base(repository, mapper)
        {
            _scheduleService = scheduleService;
            _protector = dataProtector.CreateProtector("sql-server-pass-protector");
        }

        public async Task<Guid> AddServerWithSchedule(ServerModel model)
        {
            model.Password = _protector.Protect(model.Password);
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
