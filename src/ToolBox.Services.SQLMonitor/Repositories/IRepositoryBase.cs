﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool includeAll = false);
        Task<Guid> CreateAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);

        Task DeleteEntityAsync(Guid id);

    }
}
