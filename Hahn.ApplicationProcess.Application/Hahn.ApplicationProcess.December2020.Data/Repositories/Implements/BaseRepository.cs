using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity) {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public virtual TEntity Edit(TEntity entity) {
            _dbContexts.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public virtual void Remove(TEntity entity) {
            _dbContexts.Entry(entity).State = EntityState.Deleted;
        }
        public virtual TEntity GetById(int id) {
            return _dbSet.Find(id);
        }
        public virtual async Task<TEntity> GetByIdAsync(int id) {
            return await _dbSet.FindAsync(id);
        }
    }
}