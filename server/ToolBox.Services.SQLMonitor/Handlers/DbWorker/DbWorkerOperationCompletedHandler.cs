using Microsoft.Extensions.Logging;
using RawRabbit;
using System.Threading.Tasks;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;

namespace ToolBox.Services.SQLMonitor.Handlers.DbWorker
{
    public class DbWorkerOperationCompletedHandler : IEventHandler<DbWorkerOperationCompleted>
    {
        private readonly IBusClient _busClient;
        private readonly ILogger _logger;
        public DbWorkerOperationCompletedHandler(IBusClient busClient,
         ILogger<DbWorkerOperationCompleted> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }
        public async Task HandleAsync(DbWorkerOperationCompleted command)
        {
            if (command.Resource != "sqlmonitor-service")
            {
                return;
            }

            _logger.LogInformation($"DbWorkerOperationCompleted: {command.Id}");



        }
    }
}
