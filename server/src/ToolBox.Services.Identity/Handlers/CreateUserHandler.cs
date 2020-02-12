using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RawRabbit;
using ToolBox.Common.Commands;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Common.Events.IdentityService;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public CreateUserHandler(IBusClient busClient,
         IIdentityService identityService,
         ILogger<AuthenticateUserHandler> logger)
        {
            _busClient = busClient;
            _identityService = identityService;
            _logger = logger;
        }
        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating user: {command.Email} {command.Name}");

            try
            {
                await _identityService.SignUpAsync(command.CommandId, command.Email, command.Name, command.Password);
                await _busClient.PublishAsync(new UserCreated(command.CommandId, command.Email));
                return;
            }
            catch (ToolBoxException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.CommandId, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.CommandId, "error", ex.Message));
                _logger.LogError(ex.Message);
            }

        }



    }
}