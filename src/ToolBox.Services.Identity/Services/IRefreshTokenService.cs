using System;
using System.Threading.Tasks;
using ToolBox.Common.Auth;

namespace ToolBox.Services.Identity.Services
{
    public interface IRefreshTokenService
    {
        Task AddAsync(Guid userId);
        Task<JsonWebToken> CreateAccessTokenAsync(string refreshToken);
    }
}