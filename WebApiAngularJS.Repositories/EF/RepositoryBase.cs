using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using WebApiAngularJS.Domain.Entities;
using WebApiAngularJS.Domain.Interfaces;
using WebApiAngularJS.Repositories.EF;

namespace WebApiAngularJS.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : DbEntity
    {
        protected AppDbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new AppDbContext();
        }
        public void Add(TEntity entity)
        {
            entity.DtInc = DateTime.Now;
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.DtAlt = DateTime.Now;
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
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            catch (DbUpdateException dbEx)
            {
                Trace.TraceInformation(dbEx.Message);
            }

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
