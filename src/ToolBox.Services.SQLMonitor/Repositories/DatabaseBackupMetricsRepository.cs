using ToolBox.Services.SQLMonitor.EF;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Repositories
{
    public class DatabaseBackupMetricsRepository : RepositoryBase<DatabaseBackupMetrics>, IDatabaseBackupMetricsRepository
    {
        public DatabaseBackupMetricsRepository(SqlMonitorDbContext context) : base(context) { }
    }
}
