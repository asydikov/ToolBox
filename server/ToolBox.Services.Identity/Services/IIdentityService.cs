using System;
using System.Threading.Tasks;
using ToolBox.Common.Auth;

namespace ToolBox.Services.Identity.Services
{
    public interface IIdentityService
    {
        Task<Guid> SignUpAsync(string email, string name, string password);
        Task<JsonWebToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
    }
}