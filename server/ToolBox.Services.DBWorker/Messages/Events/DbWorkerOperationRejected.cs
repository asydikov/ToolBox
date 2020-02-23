﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.DBWorker.Messages.Events
{
    [MessageNamespace("dbworker")]

    public class DbWorkerOperationRejected : IEvent
    {
        public Guid Id { get; }
        public Guid SQLServerId { get; }
        public Guid DatabaseId { get; }
        public string Name { get; }
        public string Resource { get; }
        public string Code { get; }
        public string Message { get; }


        [JsonConstructor]
        public DbWorkerOperationRejected(Guid id,
            Guid sqlServerId, Guid databaseId, string name, string resource,
            string code, string message)
        {
            Id = id;
            SQLServerId = sqlServerId;
            DatabaseId = databaseId;
            Name = name;
            Resource = resource;
            Code = code;
            Message = message;
        }
    }
}