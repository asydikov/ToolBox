using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToolBox.Common.Events;
using Toolbox.Common.Messages;

namespace ToolBox.Services.Notification.Messages.Events
{
    [MessageNamespace("notification")]
    public class DatabaseSpaceMetricsEvent : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid DatabaseId { get; set; }
        public double Space { get; set; }
        public double UnallocatedSpace { get; set; }
        public string Unit { get; set; }

        [JsonConstructor]
        public DatabaseSpaceMetricsEvent(Guid id, Guid userId, Guid databaseId, double space, double unallocatedSpace, string unit)
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
