using Core.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IEntityBaseService<EntityType, EntityKeyType> where EntityType : class, IEntityBase<EntityKeyType>, new()
    {
        Task<EntityType> GetAsync(EntityKeyType id);
        Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate);
        Task<EntityType> GetAsync(EntityKeyType id, params Expression<Func<EntityType, object>>[] includeProperties);
        Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);

        Task AddAsync(EntityType entity);
        Task DeleteAsync(EntityKeyType id);
        Task UpdateAsync(EntityType entity);
        Task<IEnumerable<EntityType>> GetAllAsync();

        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate);
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);

        Task<bool> AnyAsync();

        Task<bool> IsExistsAsync(EntityKeyType id);
        Task<bool> IsExistsAsync(Expression<Func<EntityType, bool>> predicate);

    }
}
