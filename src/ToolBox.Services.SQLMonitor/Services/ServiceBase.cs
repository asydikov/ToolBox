using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Repositories;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class ServiceBase<TModel, TEntity> : IServiceBase<TModel, TEntity>
        where TModel : ModelBase
        where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        protected readonly IMapper _mapper;

        public ServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TModel> GetAsync(Guid id)
        {
            TEntity entity = await _repository.GetAsync(id);
            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = await _repository.GetAsync(predicate);
            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<Guid> CreateAsync(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task AddRangeAsync(List<TModel> models)
        {
            List<TEntity> entities = new List<TEntity>();

            foreach (var model in models)
            {
                TEntity entity = _mapper.Map<TEntity>(model);
                entities.Add(entity);
            }

            await _repository.AddRangeAsync(entities);
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(Guid id)
        {
            await _repository.DeleteEntityAsync(id);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool includeAll = false)
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync(predicate, includeAll);
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);
        }


    }
}
