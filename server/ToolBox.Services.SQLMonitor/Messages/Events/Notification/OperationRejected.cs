using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.SQLMonitor.Messages.Events.Notification
{
    [MessageNamespace("notification")]
    public class OperationRejected : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ServerId { get; set; }
        public string Name { get; }
        public string Resource { get; }
        public string Code { get; }
        public string Message { get; }

        [JsonConstructor]
        public OperationRejected(Guid id,
            Guid userId, Guid serverId,string name, string resource,
            string code, string message)
        {
            Id = id;
            UserId = userId;
            ServerId = serverId;
            Name = name;
            Resource = resource;
            Code = code;
            Message = message;
        }
    }
}
