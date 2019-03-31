using Infrastructure.DAO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Core.Models.Entities.Abstract;
using Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public abstract class EntityBaseRepository<EntityType, EntityKeyType> : IEntityBaseRepository<EntityType, EntityKeyType> where EntityType : class, IEntityBase<EntityKeyType>, new()
    {
        private readonly ApplicationDbContext _context;

        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual IEnumerable<EntityType> GetAll()
        {
            return _context.Set<EntityType>().AsEnumerable();
        }

        public virtual int Count()
        {
            return _context.Set<EntityType>().Count();
        }
        public virtual IEnumerable<EntityType> AllIncluding(params Expression<Func<EntityType, object>>[] includeProperties)
        {
            IQueryable<EntityType> query = _context.Set<EntityType>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public EntityType GetSingle(EntityKeyType id)
        {
            return _context.Set<EntityType>().FirstOrDefault(x => x.Id.ToString() == id.ToString());
        }

        public EntityType GetSingle(Expression<Func<EntityType, bool>> predicate)
        {
            return _context.Set<EntityType>().FirstOrDefault(predicate);
        }

        public EntityType GetSingle(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            IQueryable<EntityType> query = _context.Set<EntityType>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<EntityType> FindBy(Expression<Func<EntityType, bool>> predicate)
        {
            return _context.Set<EntityType>().Where(predicate);
        }

        public IEnumerable<EntityType> FindBy(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            IQueryable<EntityType> query = _context.Set<EntityType>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate);
        }

        public virtual void Add(EntityType entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<EntityType>(entity);
            _context.Set<EntityType>().Add(entity);
        }

        public virtual void Update(EntityType entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<EntityType>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(EntityType entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<EntityType>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<EntityType, bool>> predicate)
        {
            IEnumerable<EntityType> entities = _context.Set<EntityType>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<EntityType>(entity).State = EntityState.Deleted;
            }
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<IEnumerable<EntityType>> AllIncludingAsync(params Expression<Func<EntityType, object>>[] includeProperties)
        {
            IQueryable<EntityType> query = _context.Set<EntityType>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<EntityType>> GetAllAsync()
        {
            return await _context.Set<EntityType>().ToListAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.Set<EntityType>().CountAsync();
        }

        public async Task<EntityType> GetSingleAsync(EntityKeyType id)
        {
            return await _context.Set<EntityType>().FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString());
        }

        public async Task<EntityType> GetSingleAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await _context.Set<EntityType>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsExistsAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await _context.Set<EntityType>().AnyAsync(predicate);
        }

        public async Task<EntityType> GetSingleAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            IQueryable<EntityType> query = _context.Set<EntityType>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await _context.Set<EntityType>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            IQueryable<EntityType> query = _context.Set<EntityType>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(EntityType entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<EntityType>(entity);
            await _context.Set<EntityType>().AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
