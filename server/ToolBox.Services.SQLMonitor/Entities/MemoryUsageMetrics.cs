using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class MemoryUsageMetrics:EntityBase
    {
        public Guid ServerId { get; set; }
        public Server Server { get; set; }
        public int PageLifetime { get; set; }
        public int RequestsCount { get; set; }
        public int PageReadsCount { get; set; }
    }
}
