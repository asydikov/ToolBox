using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.DBWorker.Messages.Events
{
    [MessageNamespace("dbworker")]
    public class DbWorkerOperationCompleted<TKey, TResult> : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; set; }
        public Guid SqlServerId { get; }
        public Guid DatabaseId { get; }
        public string Resource { get; }
        public List<Dictionary<TKey, TResult>> Result { get; }

        [JsonConstructor]
        public DbWorkerOperationCompleted(Guid id, Guid userId, Guid sqlServerId, Guid databaseId, string resource, List<Dictionary<TKey, TResult>> result)
        {
            Id = id;
            UserId = userId;
            SqlServerId = sqlServerId;
            DatabaseId = databaseId;
            Resource = resource;
            Result = result;
        }
    }
}
