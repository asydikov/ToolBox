using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Exceptions;
using ToolBox.Services.DBWorker.Messages.Commands;
using ToolBox.Services.DBWorker.Messages.Events;
using ToolBox.Services.DBWorker.Services;


namespace ToolBox.Services.DBWorker.Handlers
{
    public class SQLStoredProcedureQueryHandler : ICommandHandler<SQLStoredProcedureQuery>
    {
        private readonly IBusClient _busClient;
        private readonly ISQLService _sqlService;
        private readonly ILogger _logger;
        public SQLStoredProcedureQueryHandler(IBusClient busClient,
         ISQLService sqlService,
         ILogger<SQLStatementQueryHandler> logger)
        {
            _busClient = busClient;
             _sqlService = sqlService;
            _logger = logger;
        }
        public async Task HandleAsync(SQLStoredProcedureQuery command)
        {
            _logger.LogInformation($"DB worker stored procedure handler: {command.Id}");

            //try
            //{
            var result = await _sqlService.SendSQLServerRequest(command.GetConncetionString(), command.StoredProcedureName, isProcedure: true, command.Parameters);
            await _busClient.PublishAsync(new DbWorkerOperationCompleted(Guid.NewGuid(), command.SQLServerId, command.DatabaseId, command.Resource, result));
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
