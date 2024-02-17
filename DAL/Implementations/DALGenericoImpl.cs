using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        protected readonly CursosContext _Context;

        public DALGenericoImpl(CursosContext context)
        {
            _Context = context;
        }
        public bool Add(TEntity entity)
        {
            try
            {
                _Context.Add(entity);
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;      
            }
        }

        public TEntity Get(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Attach(entity);
                _Context.Set<TEntity>().Remove(entity);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }
    }
}
