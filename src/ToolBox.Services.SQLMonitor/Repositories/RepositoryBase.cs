using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.EF;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly SqlMonitorDbContext _context;

        public RepositoryBase(SqlMonitorDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
            return entity;
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public virtual async Task<Guid> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
             _context.SaveChanges();
            return entity.Id;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
             _context.SaveChanges();
        }

        public virtual async Task DeleteEntityAsync(Guid id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            entity.Disable();
            await UpdateAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool includeAll = false)
        {
            var query = _context.Set<TEntity>().AsQueryable();


            if (includeAll == true)
            {
                query = query.Include(_context.GetIncludePaths(typeof(TEntity)));
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return  query.ToList();
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
             _context.SaveChanges();
        }
    }
}
