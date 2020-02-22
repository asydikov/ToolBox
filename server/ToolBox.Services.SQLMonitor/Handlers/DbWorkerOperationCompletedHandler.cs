using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Messages.Events;

namespace ToolBox.Services.SQLMonitor.Handlers
{
    public class DbWorkerOperationCompletedHandler : IEventHandler<DbWorkerOperationCompleted>
    {
        private readonly IBusClient _busClient;
        //private readonly ISQLService _sqlService;
        private readonly ILogger _logger;
        public DbWorkerOperationCompletedHandler(IBusClient busClient,
         //ISQLService sqlService,
         ILogger<DbWorkerOperationCompletedHandler> logger)
        {
            _busClient = busClient;
            //_sqlService = sqlService;
            _logger = logger;
        }
        public async Task HandleAsync(DbWorkerOperationCompleted command)
        {

            foreach (KeyValuePair<string, string> item in command.Result[0])
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            _logger.LogInformation($" sql monitor handler: {command.Id}");

            //try
            //{
            // var result = await _sqlService.SendSQLServerRequest(command.GetConncetionString(), command.Instruction, isProcedure: false);
            //await _busClient.PublishAsync(new DbWorkerOperationCompleted(Guid.NewGuid(), command.SQLServerId, command.DatabaseId, command.Resource, result));
            //}
            //catch (ToolBoxException ex)
            //{
            //    await _busClient.PublishAsync(new OperationRejected(command.Id, command.UserId, "password-changed", "identity service", ex.Code, ex.Message));
            //    _logger.LogError(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    await _busClient.PublishAsync(new OperationRejected(command.Id, command.UserId, "password-changed", "identity service", "error", ex.Message));
            //    _logger.LogError(ex.Message);
            //}

        }
    }
}
