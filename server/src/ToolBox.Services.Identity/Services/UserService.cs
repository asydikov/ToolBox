using System.Threading.Tasks;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(CreateUser command)
        {
            User user = await _repository.GetByEmailAsync(command.Email);

            if (user != null)
            {
                throw new ToolBoxException("Email in use", $"Email: '{command.Email} is already in use");
            }

            User entity = new User(command.Email, command.Name, command.Password);

            await _repository.AddAsync(entity);
        }
    }
}