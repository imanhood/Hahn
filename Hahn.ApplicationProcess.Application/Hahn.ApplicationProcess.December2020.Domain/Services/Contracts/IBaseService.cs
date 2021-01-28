using Hahn.ApplicationProcess.December2020.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Domain.Services.Contracts {
    public interface IBaseService<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity input);
        TEntity Edit(TEntity input);
        void Remove(TEntity entity);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
    }
}
