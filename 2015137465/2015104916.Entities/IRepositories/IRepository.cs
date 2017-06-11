using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _2015104916.Entities.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Read
        TEntity Get(int? Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        

        //Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
