using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Services.DBWorker.Helpers;
using ToolBox.Services.DBWorker.Messages.Commands;
using ToolBox.Services.DBWorker.Messages.Events;
using ToolBox.Services.DBWorker.Services;


namespace ToolBox.Services.DBWorker.Handlers
{
    public class SqlStatementQueryHandler : ICommandHandler<SqlStatementQuery>
    {
        private readonly IBusClient _busClient;
        private readonly ISQLService _sqlService;
        private readonly ILogger _logger;
        public SqlStatementQueryHandler(IBusClient busClient,
         ISQLService sqlService,
         ILogger<SqlStatementQueryHandler> logger)
        {
            _busClient = busClient;
            _sqlService = sqlService;
            _logger = logger;
        }
        public async Task HandleAsync(SqlStatementQuery command)
        {
            _logger.LogInformation($"Processing: {command.Id}");

            try
            {
                var result = await _sqlService.SendSqlServerRequest(
                     ConnectionHelper.GetConncetionString(command.Host, command.Port, command.Login, command.Password, command.DatabaseName),
                     command.Instruction, isProcedure: false);

                await _busClient.PublishAsync(new DbWorkerOperationCompleted(Guid.NewGuid(), command.UserId, command.SqlServerId,
                      command.DatabaseId, command.SqlQueryName, command.Resource, result));
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new DbWorkerOperationRejected(command.Id, command.UserId, command.SqlServerId, command.DatabaseId,
                "sql statement query execution", "dbworker-service", "error", ex.Message));

                _logger.LogError(command.Id.ToString(),ex.Message);
            }
        }
    }
}
