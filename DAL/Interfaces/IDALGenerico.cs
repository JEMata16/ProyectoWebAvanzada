using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDALGenerico <TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        bool Add(TEntity entity);
        bool Remove(TEntity entity);
    }
}
