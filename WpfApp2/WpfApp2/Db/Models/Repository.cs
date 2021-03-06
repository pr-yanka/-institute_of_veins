﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using System.Data.Entity.Core;
using System.Linq.Expressions;

namespace WpfApp2.Db.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;

        public virtual IEnumerable<TEntity> GetAll
        {
            get
            {

                return dbContext.Set<TEntity>().ToList();
            }
        }
                
        public Repository(DbContext context)
        {
            dbContext = context;
        }

        public virtual TEntity Get(int id)
        {
            try  {
                return dbContext.Set<TEntity>().Find(id);
            }
            catch (EntityCommandExecutionException ex)
            {
                return null;
            }
        }

        public void Add(TEntity entry)
        {
            dbContext.Set<TEntity>().Add(entry);
        }

        public void Remove(TEntity entry)
        {
            dbContext.Set<TEntity>().Remove(entry);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> Take(int count)
        {
            return dbContext.Set<TEntity>().Take(count);
        }

    }
}
