using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolBox.Common.Exceptions;
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

        public async Task<User> GetByEmailAsync(string email)
         => await _context.Users.FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        public async Task AddAsync(User user)
        {

            Console.WriteLine($"------------------------------------------------------------{_context.ContextId}------------------------------------------------------------");
            Console.WriteLine($"User repository: Guid{user.Id}; Name - {user.Name}{user.Email}{user.Password}");

            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ToolBoxException("Exception from UserRespository", ex.InnerException.Message);
            }

        }


        public async Task<IEnumerable<User>> BrowseAsync()
            => await _context.Users.ToListAsync();


    }
}