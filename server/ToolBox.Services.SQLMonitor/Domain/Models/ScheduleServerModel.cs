using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class ScheduleServerModel
    {
        public Guid ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; }
        public Guid ServerId { get; set; }
        public ServerModel Server { get; set; }
    }
}
