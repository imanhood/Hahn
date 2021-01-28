using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts {
    public interface IBaseRepository<TEntity, TDBContext> {
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Edit(TEntity entity);
        void Remove(TEntity id);
    }
}
