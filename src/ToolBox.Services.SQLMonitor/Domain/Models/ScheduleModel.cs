using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class ScheduleModel : ModelBase
    {
        public int Interval { get; set; }
        public DateTime LastInvokedDate { get; set; }
        public bool IsForServer { get; set; }
        public List<ScheduleSqlQueryModel> ScheduleSqlQueries { get; set; }
        public List<ScheduleServerModel> ScheduleServers { get; set; }
    }
}
