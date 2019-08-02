using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookHome.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Insert(TEntity model, bool persist = false);

        TEntity Update(TEntity model, bool persist = false);

        void Delete(long id, bool persist = false);

        void Delete(TEntity model, bool persist = false);

        TEntity Get(object id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
    }


}
