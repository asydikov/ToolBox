using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class ScheduleDatabase
    {
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public Guid DatabaseId { get; set; }
        public Database Database { get; set; }
    }
}
