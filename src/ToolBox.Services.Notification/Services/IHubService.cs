﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.Notification.Messages.Events;

namespace ToolBox.Services.Notification.Services
{
    public interface IHubService
    {
        Task PublishOperationPendingAsync(OperationPending @event);
        Task PublishOperationCompletedAsync(OperationCompleted @event);
        Task PublishOperationRejectedAsync(OperationRejected @event);
        Task PublishServerMemoryUsageMetricsAsync(ServerMemoryUsageMetricsCompleted @event);
        Task PublishUserSessionMetricsAsync(UserSessionMetricsCompleted @event);
        Task PublishDatabaseSpaceMetricsEventAsync(DatabaseSpaceUsageMetricsCompleted @event);

    }
}
