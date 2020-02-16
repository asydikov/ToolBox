using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RawRabbit;
using ToolBox.Common.Commands;

using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Messages.Commands;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public SignInHandler(IBusClient busClient,
         IIdentityService identityService,
         ILogger<SignInHandler> logger)
        {
            _busClient = busClient;
            _identityService = identityService;
            _logger = logger;
        }
        public async Task HandleAsync(SignIn command)
        {
           /* _logger.LogInformation($"Authenticating user: {command.Email}");

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
            }*/

        }

    }
}