using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApiAngularJS.Domain.Interfaces;
using WebApiAngularJS.Repositories.EF;

namespace WebApiAngularJS.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected AppDbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new AppDbContext();
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetList()
        {
            return Context.Set<TEntity>().ToList();
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this.Context == null)
            {
                return;
            }
            this.Context.Dispose();
            this.Context = null;
        }
    }
}
