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
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public SignUpHandler(IBusClient busClient,
         IIdentityService identityService,
         ILogger<SignUpHandler> logger)
        {
            _busClient = busClient;
            _identityService = identityService;
            _logger = logger;
        }
        public async Task HandleAsync(SignUp command)
        {
         /*   _logger.LogInformation($"Sign up handler in Identity  service: {command.Email} {command.Name}");

            try
            {
                await _identityService.SignUpAsync(command.Id, command.Email, command.Name, command.Password);
                await _busClient.PublishAsync(new UserCreated(command.Id, command.Email));
                return;
            }
            catch (ToolBoxException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Id, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Id, "error", ex.Message));
                _logger.LogError(ex.Message);
            }*/

        }



    }
}