using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Services
{
    public class ClaimsProvider : IClaimsProvider
    {
        public async Task<IDictionary<string, string>> GetAsync(User user)
        {
            return await Task.FromResult(new Dictionary<string, string>
            {
                ["name"] = user.Name,
                ["email"] = user.Email,
            });
        }
    }
}