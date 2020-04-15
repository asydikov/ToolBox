using System;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class ScheduleServer
    {
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public Guid ServerId { get; set; }
        public Server Server { get; set; }
    }
}
