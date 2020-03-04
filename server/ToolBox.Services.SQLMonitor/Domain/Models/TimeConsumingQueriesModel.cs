using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class TimeConsumingQueriesModel
    {
        public int AvgCPUTime { get; set; }
        public string StatementText { get; set; }
    }
}
