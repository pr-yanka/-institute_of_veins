using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

namespace WpfApp2.Db.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;

        public IEnumerable<TEntity> GetAll
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

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
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
    }
}
