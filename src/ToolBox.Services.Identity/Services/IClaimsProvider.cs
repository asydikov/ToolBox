using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Services
{
    public interface IClaimsProvider
    {
        Task<IDictionary<string, string>> GetAsync(User user);
    }
}