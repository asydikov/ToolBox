using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;

namespace ToolBox.Services.SQLMonitor.Services
{
    public interface IServerService : IServiceBase<ServerModel, Server>
    {
        Task<Guid> AddServerWithSchedule(ServerModel model);
    }
}
