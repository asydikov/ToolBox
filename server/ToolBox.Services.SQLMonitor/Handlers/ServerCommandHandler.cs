using AutoMapper;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Messages.Commands;
using ToolBox.Services.SQLMonitor.Messages.Events.Notification;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.SQLMonitor.Handlers
{
    public class CheckServerConnectionHandler : ICommandHandler<ServerCommand>
    {
        private readonly IBusClient _busClient;
        private readonly IServerService _serverService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CheckServerConnectionHandler(IBusClient busClient, IServerService serverService, IMapper mapper, ILogger<CheckServerConnectionHandler> logger)
        {
            _busClient = busClient;
            _serverService = serverService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task HandleAsync(ServerCommand command)
        {
            _logger.LogInformation($"Sql monitor service: {command.Id}");

            var result = await _serverService.CreateAsync(new ServerModel
            {
                UserId = command.UserId,
                Name = command.Name,
                Host = command.Host,
                Port = command.Port,
                Login = command.Login,
                Password = command.Password
            });

            // check connection to a server
            await _busClient.PublishAsync(new OperationCompleted(command.Id, command.UserId, "sql-monitor", result.ToString()));
        }
    }
}
