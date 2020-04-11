using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.SQLMonitor.Messages.Events.DbWorker
{
    [MessageNamespace("dbworker")]
    public class DbWorkerOperationCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; set; }
        public Guid SqlServerId { get; }
        public Guid DatabaseId { get; }
        public int SqlQueryName { get; }
        public string Resource { get; }
        public List<Dictionary<string, string>> Result { get; }

        [JsonConstructor]
        public DbWorkerOperationCompleted(Guid id, Guid userId, Guid sqlServerId, Guid databaseId, int sqlQueryName, string resource, List<Dictionary<string, string>> result)
        {
            Id = id;
            UserId = userId;
            SqlServerId = sqlServerId;
            DatabaseId = databaseId;
            SqlQueryName = sqlQueryName;
            Resource = resource;
            Result = result;
        }
    }
}
