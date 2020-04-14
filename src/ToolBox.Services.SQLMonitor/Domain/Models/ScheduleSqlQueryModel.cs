using System;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class ScheduleSqlQueryModel
    {
        public Guid ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; }
        public Guid SqlQueryId { get; set; }
        public SqlQueryModel SqlQuery { get; set; }
    }
}
