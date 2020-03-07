﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToolBox.Common.Events;
using Toolbox.Common.Messages;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Messages.Events.Notification
{
    [MessageNamespace("notification")]
    public class UserSessionMetrics : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ServerId { get; set; }
        public List<string> ConnectedUsers { get; set; }

        [JsonConstructor]
        public UserSessionMetrics(Guid id, Guid userId, Guid serverId, List<string> connectedUsers)
        {
            Id = id;
            UserId = userId;
            ServerId = serverId;
            ConnectedUsers = connectedUsers;
        }
    }
}
