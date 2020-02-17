using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Messages.Commands;
using ToolBox.Services.Identity.Messages.Events;
using ToolBox.Services.Identity.Messages.Events.Notification;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.Handlers
{
    public class ChangePasswordHandler: ICommandHandler<ChangePassword>
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public ChangePasswordHandler(IBusClient busClient,
         IIdentityService identityService,
         ILogger<ChangePasswordHandler> logger)
        {
            _busClient = busClient;
            _identityService = identityService;
            _logger = logger;
        }
        public async Task HandleAsync(ChangePassword command)
        {
            _logger.LogInformation($"Change password handler in Identity  service: {command.Id} {command.UserId}");

            try
            {
                await _identityService.ChangePasswordAsync(command.UserId, command.CurrentPassword, command.NewPassword);
                await _busClient.PublishAsync(new OperationCompleted(command.Id, command.UserId, "password-changed", "identity service"));
            }
            catch (ToolBoxException ex)
            {
                await _busClient.PublishAsync(new OperationRejected(command.Id,command.UserId, "password-changed", "identity service", ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new OperationRejected(command.Id, command.UserId, "password-changed", "identity service", "error", ex.Message));
                _logger.LogError(ex.Message);
            }

        }
    }
}
