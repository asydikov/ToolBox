﻿using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;

namespace ToolBox.Services.SQLMonitor.Services
{
    public interface IMetricsProcessingService
    {
        Task ProcessMetrics(DbWorkerOperationCompleted command);
    }
}
