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
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        public CreateUserHandler(IBusClient busClient,
        IUserService userService,
        ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }
        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating user: {command.Email} {command.Name}");

            try
            {
                await _userService.AddAsync(command);
                await _busClient.PublishAsync(new UserCreated(Guid.NewGuid(), command.Email, command.Name));
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