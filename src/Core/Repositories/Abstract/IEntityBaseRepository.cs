using Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Abstract
{
    public interface IEntityBaseRepository<EntityType, EntityKeyType> where EntityType : class, IEntityBase<EntityKeyType>, new()
    {
        IEnumerable<EntityType> AllIncluding(params Expression<Func<EntityType, object>>[] includeProperties);
        IEnumerable<EntityType> GetAll();
        int Count();
        EntityType GetSingle(EntityKeyType id);
        EntityType GetSingle(Expression<Func<EntityType, bool>> predicate);
        EntityType GetSingle(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);
        IEnumerable<EntityType> FindBy(Expression<Func<EntityType, bool>> predicate);
        IEnumerable<EntityType> FindBy(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);
        void Add(EntityType entity);
        void Update(EntityType entity);
        void Delete(EntityType entity);
        void DeleteWhere(Expression<Func<EntityType, bool>> predicate);
        void Commit();

        // Task part
        Task<IEnumerable<EntityType>> AllIncludingAsync(params Expression<Func<EntityType, object>>[] includeProperties);
        Task<IEnumerable<EntityType>> GetAllAsync();
        Task<int> CountAsync();
        Task<EntityType> GetSingleAsync(EntityKeyType id);
        Task<EntityType> GetSingleAsync(Expression<Func<EntityType, bool>> predicate);
        Task<EntityType> GetSingleAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate);
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);
        Task<bool> IsExistsAsync(Expression<Func<EntityType, bool>> predicate);
        Task AddAsync(EntityType entity);
        Task CommitAsync();
    }
}
