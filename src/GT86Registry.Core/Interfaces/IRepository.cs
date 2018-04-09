using GT86Registry.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GT86Registry.Core.Interfaces
{
    /// <summary>
    /// IRepository interface serves as a generic CRUD API. Operations are performed using synchronous methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        T AddEntity(T entity);

        void Delete(T entity);

        void Delete(int id);

        IEnumerable<T> GetAll();

        IQueryable<T> GetAllQueryable();

        T GetById(int id);

        void Update(T entity);
    }
}