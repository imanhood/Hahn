using Hahn.ApplicationProcess.December2020.Data;
using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Implements;
using Hahn.ApplicationProcess.December2020.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Domain.Services.Implements {
    public class BaseService<TEntity, TRepository> : IBaseService<TEntity> 
        where TEntity : BaseEntity
        where TRepository : IBaseRepository<TEntity, DBContexts>
    {
        private readonly TRepository _repository;
        public BaseService(TRepository repository) {
            _repository = repository;
        }
        public TEntity GetById(int id) {
            return _repository.GetById(id);
        }
        public async Task<TEntity> GetByIdAsync(int id) {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<TEntity> AddAsync(TEntity input) {
            return await _repository.AddAsync(input);
        }
        public TEntity Edit(TEntity input) {
            return _repository.Edit(input);
        }
        public void Remove(TEntity entity) {
            _repository.Remove(entity);
        }
    }
}