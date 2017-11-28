using GT86Registry.Core.Entities;
using System.Collections.Generic;

namespace GT86Registry.Core.Interfaces
{
    /// <summary>
    /// IRepository interface serves as a generic CRUD API. Operations are performed using synchronous methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T AddEntity(T entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
