using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;

namespace ToolBox.Services.SQLMonitor.Services
{
    public interface IServiceBase<TModel> where TModel : ModelBase
    {
        Task<TModel> GetAsync(Guid id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<Guid> CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteEntityAsync(Guid id);
    }
}
