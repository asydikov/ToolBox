using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class ScheduleSqlQuery
    {
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public Guid SqlQueryId { get; set; }
        public SqlQuery SqlQuery { get; set; }
    }
}
