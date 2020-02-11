using System.Threading.Tasks;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Services
{
    public interface IUserService
    {
        Task AddAsync(CreateUser command);
    }
}