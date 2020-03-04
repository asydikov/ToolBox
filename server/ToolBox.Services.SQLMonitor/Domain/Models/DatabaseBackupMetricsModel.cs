using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class DatabaseBackupMetricsModel:ModelBase
    {
        public Guid DatabaseId { get; set; }
        public DateTime? Full { get; set; }
        public DateTime? Differential { get; set; }
        public DateTime? Transaction { get; set; }
        public string RecoveryModel { get; set; }
    }
}
