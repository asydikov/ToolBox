using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Services
{
    public interface IMemoryUsageMetricsService : IServiceBase<MemoryUsageMetricsModel, MemoryUsageMetrics>
    {
    }
}
