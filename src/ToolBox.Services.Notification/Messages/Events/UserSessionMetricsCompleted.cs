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
    public class UserSessionMetricsCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ServerId { get; set; }
        public List<string> ConnectedUsers { get; set; }


        [JsonConstructor]
        public UserSessionMetricsCompleted(Guid id, Guid userId, Guid serverId, List<string> connectedUsers)
        {
            Id = id;
            UserId = userId;
            ServerId = serverId;
            ConnectedUsers = connectedUsers;
        }

    }
}
