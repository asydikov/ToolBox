using AutoMapper;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Messages.Commands;
using ToolBox.Services.SQLMonitor.Messages.Events.Notification;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.SQLMonitor.Handlers
{
    public class ServerCommandHandler : ICommandHandler<ServerCreation>
    {
        private readonly IBusClient _busClient;
        private readonly IServerService _serverService;
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ServerCommandHandler(IBusClient busClient,
            IServerService serverService,
            IDatabaseService databaseService,
            IMapper mapper,
            ILogger<ServerCommandHandler> logger)
        {
            _busClient = busClient;
            _serverService = serverService;
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task HandleAsync(ServerCreation command)
        {
            _logger.LogInformation($"Processing: {command.Id}");

            try
            {
                var result = await _serverService.AddServerWithSchedule(new ServerModel
                {
                    UserId = command.UserId,
                    Name = command.Name,
                    Host = command.Host,
                    Port = command.Port,
                    Login = command.Login,
                    Password = command.Password,
                    Description = command.Description
                });

                // command to add databases
                await _busClient.PublishAsync(new SqlStoredProcedureQuery(Guid.NewGuid(),
                    command.UserId,
                    "sp_databases",
                    null,
                    command.Host,
                    command.Port,
                    command.Login,
                    command.Password,
                    null,
                    (int)SqlQueryNames.DatabaseNames,
                    result,
                    Guid.Empty,
                    "sqlmonitor-service"
                ));

                await _busClient.PublishAsync(new OperationCompleted(command.Id, command.UserId, "sql-server-added", result.ToString()));

            }
            catch (Exception ex)
            {
                _logger.LogError(command.Id.ToString(), ex.Message);
            }
        }
    }
}
