using System;
using System.Collections.Generic;


namespace ToolBox.Services.SQLMonitor.Entities
{
    public class Schedule : EntityBase
    {
        public int Interval { get; set; }
        public DateTime LastInvokedDate { get; set; }
        public bool IsForServer { get; set; }

        public virtual ICollection<ScheduleSqlQuery> ScheduleSqlQueries { get; set; }
        public virtual ICollection<ScheduleServer> ScheduleServers { get; set; }

    }
}
