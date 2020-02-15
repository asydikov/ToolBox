using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.Notification.Framework;
using ToolBox.Services.Notification.Hubs;

namespace ToolBox.Services.Notification.Services
{
    public class HubWrapper : IHubWrapper
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public HubWrapper(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task PublishToUserAsync(Guid userId, string message, object data)
            => await _hubContext.Clients.Group(userId.ToUserGroup()).SendAsync(message, data);

        public async Task PublishToAllAsync(string message, object data)
            => await _hubContext.Clients.All.SendAsync(message, data);
    }
}
