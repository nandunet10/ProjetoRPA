﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestAec.Domain.AggregatesModel;

namespace TestAec.Infrastructure.Repositories
{
    public abstract class SqlServerRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }

        protected DbSet<TEntity> Entity => Context.Set<TEntity>();

        public SqlServerRepository() { }

        public SqlServerRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity model)
        {
            Context.Set<TEntity>().Add(model);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Where(expression);
        }

        public void Remove(TEntity model)
        {
            Context.Entry(model).State = EntityState.Deleted;
        }

        public void Update(TEntity model)
        {
            Context.Entry(model).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}