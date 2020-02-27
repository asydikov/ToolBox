using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
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

            var line = new StringBuilder();
            var line1 = new StringBuilder();
            var count = 0;

            foreach (var result in command.Result)
            {
                foreach (KeyValuePair<string, string> item in result)
                {
                    //_logger.LogInformation($"{item.Key}");
                    if (count < 3)
                    {
                        line.Append(item.Key + "  ");
                    }
                    line1.Append(item.Value + "  ");
                    count += 1;
                }

                line1.Append(Environment.NewLine);
            }

            _logger.LogInformation($"{line} {Environment.NewLine} {line1}");

        }
    }
}
