using System;
using Newtonsoft.Json;
using ToolBox.Common.Events;
using Toolbox.Common.Messages;

namespace ToolBox.Services.SQLMonitor.Messages.Events.Notification
{
    [MessageNamespace("notification")]
    public class DatabaseSpaceUsageMetricsCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid DatabaseId { get; set; }
        public double Space { get; set; }
        public double UnallocatedSpace { get; set; }
        public string Unit { get; set; }

        [JsonConstructor]
        public DatabaseSpaceUsageMetricsCompleted(Guid id, Guid userId, Guid databaseId, double space, double unallocatedSpace, string unit)
        {
            Id = id;
            UserId = userId;
            DatabaseId = databaseId;
            Space = space;
            UnallocatedSpace = unallocatedSpace;
            Unit = unit;
        }
    }
}
