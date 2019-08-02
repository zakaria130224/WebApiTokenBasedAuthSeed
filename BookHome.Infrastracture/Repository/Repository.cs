using BookHome.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookHome.Infrastracture.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DBContext context;
        internal DbSet<TEntity> dbSet;

        public Repository()
        {
            context = new DBContext();
            dbSet = context.Set<TEntity>();
        }
        public void Delete(long id, bool persist = false)
        {
            dbSet.Remove(dbSet.Find(id));
            context.SaveChanges();
        }

        public void Delete(TEntity model, bool persist = false)
        {
            dbSet.Remove(model);

            context.SaveChanges();
        }

        public TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity Insert(TEntity model, bool persist = false)
        {
            dbSet.Add(model);
            context.SaveChanges();
            return model;
        }

        public TEntity Update(TEntity model, bool persist = false)
        {
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            return model;
        }
    }
}
