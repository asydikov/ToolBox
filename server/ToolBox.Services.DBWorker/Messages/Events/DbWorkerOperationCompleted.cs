using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.DBWorker.Messages.Events
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
        public DbWorkerOperationCompleted(Guid id, Guid sQLServerId, Guid databaseId, string resource, List<Dictionary<string, string>> result)
        {
            Id = id;
            SQLServerId = sQLServerId;
            DatabaseId = databaseId;
            Resource = resource;
            Result = result;
        }
    }
}
