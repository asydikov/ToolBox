using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;

namespace ToolBox.Services.SQLMonitor.Services
{
    public interface IServiceBase<TModel, TEntity> where TModel : ModelBase
    {
        Task<TModel> GetAsync(Guid id);
        Task<TModel> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool includeAll = false);
        Task<Guid> CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteEntityAsync(Guid id);
    }
}
