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
    public class SqlStoredProcedureQueryHandler : ICommandHandler<SqlStoredProcedureQuery>
    {
        private readonly IBusClient _busClient;
        private readonly ISQLService _sqlService;
        private readonly ILogger _logger;
        public SqlStoredProcedureQueryHandler(IBusClient busClient,
         ISQLService sqlService,
         ILogger<SqlStatementQueryHandler> logger)
        {
            _busClient = busClient;
            _sqlService = sqlService;
            _logger = logger;
        }
        public async Task HandleAsync(SqlStoredProcedureQuery command)
        {
            _logger.LogInformation($"DB worker stored procedure handler: {command.Id}");

            try
            {
                var result = await _sqlService.SendSQLServerRequest(command.GetConncetionString(), command.StoredProcedureName, isProcedure: true, command.Parameters);
                await _busClient.PublishAsync(new DbWorkerOperationCompleted(Guid.NewGuid(), command.UserId, command.SqlServerId, command.DatabaseId, command.Resource, result));
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new DbWorkerOperationRejected(command.Id,command.UserId, command.SqlServerId, command.DatabaseId, "sql stored proceure call", "dbworker-service", "error", ex.Message));
                _logger.LogError(ex.Message);
            }

        }

    }
}
