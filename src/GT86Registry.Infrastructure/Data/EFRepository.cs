using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        #region IRepository Methods
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion IRepository Methods

        #region IAsyncRepository Methods
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion IAsyncRepository Methods
    }
}
