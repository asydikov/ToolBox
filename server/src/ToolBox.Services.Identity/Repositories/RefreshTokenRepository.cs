using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolBox.Services.Identity.EF;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IdentityDbContext _context;

        public RefreshTokenRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GetAsync(string token)
            => await _context.RefreshTokens.Include(x => x.User).FirstOrDefaultAsync(x => x.Token == token);

        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            _context.RefreshTokens.Update(token);
            await _context.SaveChangesAsync();
        }
    }
}