using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Events;
using ToolBox.Services.Notification.Messages.Events;
using ToolBox.Services.Notification.Services;

namespace ToolBox.Services.Notification.Handlers
{
    public class OperationRejectedHandler:IEventHandler<OperationRejected>
    {
        private readonly IHubService _hubService;
        private readonly ILogger _logger;
        public OperationRejectedHandler(
         IHubService hubService,
         ILogger<OperationCompletedHandler> logger)
        {
            _hubService = hubService;
            _logger = logger;
        }


        public async Task HandleAsync(OperationRejected @event)
        {
            _logger.LogError($"Notification service rejected event handler. Sending notificationto user: {@event.UserId}");
            await _hubService.PublishOperationRejectedAsync(@event);
        }
    }
}
