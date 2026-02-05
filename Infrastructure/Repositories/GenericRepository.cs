using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    /// <summary>
    /// Generic EF repository implementation.
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
            DbSet.Remove(entity);
        }
    }
}
