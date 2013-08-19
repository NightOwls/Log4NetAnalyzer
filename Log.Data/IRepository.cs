using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Log.Domain;

namespace Log.Data
{
    public interface IRepository<T> 
        where T : IEntity
    {
        T Insert(T entity);

        T First(Expression<Func<T, bool>> filter);
        T FirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> Select(Expression<Func<T, bool>> filter);
        IEnumerable<T> Select(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, bool descending);

    }
}
