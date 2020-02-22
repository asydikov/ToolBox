using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.SQLMonitor.Messages.Events
{
    [MessageNamespace("dbworker")]
    public class DbWorkerOperationCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid SQLServerId { get; }
        public Guid DatabaseId { get; }
        public string Resource { get; }
        public List<Dictionary<string, string>> Result { get; }

        [JsonConstructor]
        public DbWorkerOperationCompleted(Guid id, Guid sqlServerId, Guid databaseId, string resource, List<Dictionary<string, string>> result)
        {
            Id = id;
            SQLServerId = sqlServerId;
            DatabaseId = databaseId;
            Resource = resource;
            Result = result;
        }
    }
}
