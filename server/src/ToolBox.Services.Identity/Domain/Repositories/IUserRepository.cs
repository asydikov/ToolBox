using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<IEnumerable<User>> BrowseAsync();

    }
}