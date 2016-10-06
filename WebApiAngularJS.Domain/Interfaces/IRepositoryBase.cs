using System;
using System.Collections.Generic;

namespace WebApiAngularJS.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetList();
        void SaveChanges();
    }
}
