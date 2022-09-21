using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); 
        IList<T> GetList(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
        T AddEntity(T entity);
    }
}
