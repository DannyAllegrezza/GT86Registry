using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly VehicleDbContext _vehicleContext;

        public EFRepository(VehicleDbContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        #region IRepository Methods

        public void Add(T entity)
        {
            _vehicleContext.Set<T>().Add(entity);
            _vehicleContext.SaveChanges();
        }

        public T AddEntity(T entity)
        {
            _vehicleContext.Set<T>().Add(entity);
            _vehicleContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _vehicleContext.Set<T>().Remove(entity);
            _vehicleContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _vehicleContext.Set<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return _vehicleContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _vehicleContext.Entry(entity).State = EntityState.Modified;
            _vehicleContext.SaveChanges();
        }

        #endregion IRepository Methods

        #region IAsyncRepository Methods

        public async Task<T> AddAsync(T entity)
        {
            _vehicleContext.Set<T>().Add(entity);
            await _vehicleContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _vehicleContext.Set<T>().Remove(entity);
            await _vehicleContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _vehicleContext.Set<T>().FindAsync(id);
        }

        public Task<List<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _vehicleContext.Entry(entity).State = EntityState.Modified;
            await _vehicleContext.SaveChangesAsync();
        }

        #endregion IAsyncRepository Methods
    }
}