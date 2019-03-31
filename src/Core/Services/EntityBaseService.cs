using Core.Repositories.Abstract;
using Core.Services.Abstract;
using Core.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services
{
    public abstract class EntityBaseService<EntityType, EntityKeyType> : IEntityBaseService<EntityType, EntityKeyType> where EntityType : class, IEntityBase<EntityKeyType>, new()
    {
        private readonly IEntityBaseRepository<EntityType, EntityKeyType> _repository;

        public EntityBaseService(IEntityBaseRepository<EntityType, EntityKeyType> repository)
        {
            _repository = repository;
        }

        public async Task<EntityType> GetAsync(EntityKeyType id)
        {
            return await _repository.GetSingleAsync(id);
        }

        public async Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await _repository.GetSingleAsync(predicate);
        }

        public async Task<EntityType> GetAsync(EntityKeyType id, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            return await _repository.GetSingleAsync(_ => _.Id.ToString() == id.ToString(), includeProperties);
        }

        public async Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            return await _repository.GetSingleAsync(predicate, includeProperties);
        }

        public async Task AddAsync(EntityType entity)
        {
            await _repository.AddAsync(entity);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(EntityKeyType id)
        {
            _repository.DeleteWhere(_ => _.Id.ToString() == id.ToString());
            await _repository.CommitAsync();
        }

        public async Task UpdateAsync(EntityType entity)
        {
            _repository.Update(entity);
            await _repository.CommitAsync();
        }

        public async Task<IEnumerable<EntityType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await _repository.FindByAsync(predicate);
        }

        public async Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            return await _repository.FindByAsync(predicate, includeProperties);
        }

        public async Task<bool> IsExistsAsync(EntityKeyType id)
        {
            return await IsExistsAsync(_ => _.Id.ToString() == id.ToString());
        }

        public async Task<bool> IsExistsAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await _repository.IsExistsAsync(predicate);
        }

        public async Task<bool> AnyAsync()
        {
            return await _repository.CountAsync() > 0;
        }
    }
}