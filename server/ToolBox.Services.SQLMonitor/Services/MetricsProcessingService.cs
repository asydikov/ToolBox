using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class MetricsProcessingService : IMetricsProcessingService
    {
        public Task ProcessMetrics(DbWorkerOperationCompleted command)
        {
            if (command.SqlQueryName == (int)SqlQueryNames.DatabaseSpaceStatus)
            {

            }

            if (command.SqlQueryName == (int)SqlQueryNames.DatabasesBackupStatus)
            {

            }

            if (command.SqlQueryName == (int)SqlQueryNames.ConnectedUsers)
            {

            }

            if (command.SqlQueryName == (int)SqlQueryNames.MemoryUsage)
            {

            }


            return Task.CompletedTask;
        }
    }
}
