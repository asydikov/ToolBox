using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class SqlServerBadge
    {
        public Guid ServerId { get; set; }
        public string Name { get; set; }
        public string ServerAddress { get; set; }
        public string Description { get; set; }
        public double PageReadsCounts { get; set; }
        public double RequestCount { get; set; }
        public double PageLifetime { get; set; }
        public bool IsAlive = true;

        public int ConnectedUsers = 0;
    }
}
