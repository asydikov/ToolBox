using System;


namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class DatabaseBadgeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? FullBackupTime { get; set; }
        public DateTime? DifferentialBackupTime { get; set; }
        public DateTime? TransactionLogBackupTime { get; set; }
        public string RecoveryModel { get; set; }
        public double Space { get; set; }
        public double UnallocatedSpace { get; set; }
        public string Unit { get; set; }
    }
}
