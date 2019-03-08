using Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IEntityBaseService<EntityType, EntityKey> where EntityType : class, IEntityBase<EntityKey>, new()
    {
        Task<EntityType> GetAsync(EntityKey id);
        Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate);
        Task<EntityType> GetAsync(EntityKey id, params Expression<Func<EntityType, object>>[] includeProperties);
        Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);

        Task AddAsync(EntityType entity);
        Task DeleteAsync(EntityKey id);
        Task UpdateAsync(EntityType entity);
        Task<IEnumerable<EntityType>> GetAllAsync();

        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate);
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);

        Task<bool> IsExistsAsync(EntityKey id);
        Task<bool> IsExistsAsync(Expression<Func<EntityType, bool>> predicate);
    }
}
