using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class DatabaseSpaceMetricsModel : ModelBase
    {
        public Guid DatabaseId { get; set; }
        public double Space { get; set; }
        public double UnallocatedSpace { get; set; }
        public string Unit { get; set; }
    }
}
