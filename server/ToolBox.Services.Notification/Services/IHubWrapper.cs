using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.Notification.Services
{
    public interface IHubWrapper
    {
        Task PublishToUserAsync(Guid userId, string message, object data);
        Task PublishToAllAsync(string message, object data);
    }
}
