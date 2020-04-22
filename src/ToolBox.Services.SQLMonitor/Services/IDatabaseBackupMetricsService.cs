using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Services
{
   public interface IDatabaseBackupMetricsService : IServiceBase<DatabaseBackupMetricsModel, DatabaseBackupMetrics>
    {
    }
}
