using System;
using Newtonsoft.Json;
using ToolBox.Common.Events;
using Toolbox.Common.Messages;

namespace ToolBox.Services.SQLMonitor.Messages.Events.Notification
{
    [MessageNamespace("notification")]
    public class ServerMemoryUsageMetricsCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ServerId { get; set; }
        public int RequestsCount { get; }
        public int PageReadsCount { get; }
        public int PageLifetime { get; }


        [JsonConstructor]
        public ServerMemoryUsageMetricsCompleted(
            Guid id, Guid userId, Guid serverId, int requestsCount, int pageReadsCount, int pageLifetime)
        {
            Id = id;
            UserId = userId;
            ServerId = serverId;
            RequestsCount = requestsCount;
            PageReadsCount = pageReadsCount;
            PageLifetime = pageLifetime;
        }
    }
}
