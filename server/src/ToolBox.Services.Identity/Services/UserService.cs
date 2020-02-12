using System;
using System.Threading.Tasks;
using ToolBox.Common.Auth;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Helpers;
namespace ToolBox.Services.Identity.Services
{
    public class UserService : IUserService
    {
        public UserService() { }

        public Task AddAsync(CreateUser command)
        {
            throw new NotImplementedException();
        }
    }
}