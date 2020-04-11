using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class MemoryUsageMetricsModel: ModelBase
    {
        public Guid ServerId { get; set; }
        public int PageLifetime { get; set; }
        public int RequestsCount { get; set; }
        public int PageReadsCount { get; set; }
    }
}
