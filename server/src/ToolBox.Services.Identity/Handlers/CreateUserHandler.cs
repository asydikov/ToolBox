using System;
using System.Threading.Tasks;
using RawRabbit;
using ToolBox.Common.Commands;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Common.Events.IdentityService;

namespace ToolBox.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        public CreateUserHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }
        public async Task HandleAsync(CreateUser command)
        {
            Console.WriteLine($"Creating user {command.Email}");
            await _busClient.PublishAsync(new UserCreated(Guid.NewGuid(), command.Email, command.Name));
        }



    }
}