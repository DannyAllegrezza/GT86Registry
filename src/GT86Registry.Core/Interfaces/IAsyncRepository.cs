using GT86Registry.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT86Registry.Core.Interfaces
{
    /// <summary>
    /// IAsyncRepository interface serves as a generic CRUD API. Operations are performed using asynchronous methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
