using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class DatabaseSpaceMetrics:EntityBase
    {
        public Guid DatabaseId { get; set; }
        public Database Database { get; set; }
        public double Space { get; set; }
        public double UnallocatedSpace { get; set; }
        public string Unit { get; set; }
    }
}
