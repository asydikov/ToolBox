using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.EF;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;
        public UserRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
           => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());
            // return await _context.Users.FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}