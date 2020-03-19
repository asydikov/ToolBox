using AutoMapper;
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

        public override async Task UpdateAsync(ScheduleModel model)
        {
            var entity = await _repository.GetAsync(model.Id);

            entity.Interval = model.Interval;
            entity.LastInvokedDate = model.LastInvokedDate;
            entity.IsForServer = model.IsForServer;

            await _repository.UpdateAsync(entity);
        }
    }
}
