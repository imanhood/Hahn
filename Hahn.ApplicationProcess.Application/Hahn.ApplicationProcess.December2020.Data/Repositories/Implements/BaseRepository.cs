using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Implements {
    public class BaseRepository<TEntity, TDBContext> : IBaseRepository<TEntity, TDBContext>
        where TEntity : BaseEntity
        where TDBContext : DbContext 
        {
        private readonly DBContexts _dbContexts;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(DBContexts contexts) {
            _dbContexts = contexts;
            _dbSet = _dbContexts.Set<TEntity>();
            _dbSet.AsNoTracking();
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity) {
            await _dbSet.AddAsync(entity);
            _dbContexts.SaveChanges();
            return entity;
        }
        public virtual TEntity Edit(TEntity entity) {
            var local = _dbSet.Local.FirstOrDefault(e => e.ID.Equals(entity.ID));
            if(local != null) {
                _dbContexts.Entry(local).State = EntityState.Detached;
            }
            _dbContexts.Entry(entity).State = EntityState.Modified;
            _dbContexts.SaveChanges();
            return entity;
        }
        public virtual void Remove(TEntity entity) {
            _dbContexts.Entry(entity).State = EntityState.Deleted;
            _dbContexts.SaveChanges();
        }
        public virtual TEntity GetById(int id) {
            return _dbSet.Find(id);
        }
        public virtual async Task<TEntity> GetByIdAsync(int id) {
            return await _dbSet.FindAsync(id);
        }
    }
}