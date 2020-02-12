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
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public AuthenticateUserHandler(IBusClient busClient,
         IIdentityService identityService,
         ILogger<AuthenticateUserHandler> logger)
        {
            _busClient = busClient;
            _identityService = identityService;
            _logger = logger;
        }
        public async Task HandleAsync(AuthenticateUser command)
        {
            _logger.LogInformation($"Authenticating user: {command.Email}");

            try
            {
                await _identityService.SignInAsync(command.Email, command.Password);
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