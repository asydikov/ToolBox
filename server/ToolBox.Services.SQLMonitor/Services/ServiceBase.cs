using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Repositories;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class ServiceBase<TModel, TEntity> : IServiceBase<TModel>
        where TModel : ModelBase
        where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;

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

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);
        }

        public virtual async Task<Guid> CreateAsync(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            return await _repository.CreateAsync(entity);
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
    }
}
