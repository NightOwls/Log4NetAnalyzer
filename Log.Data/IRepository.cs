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

        T First(Func<T, bool> filter);
        T FirstOrDefault(Func<T, bool> filter);
        IEnumerable<T> Select<TMember>(Expression<Func<T, TMember>> filter, TMember value);
       // IEnumerable<T> Select(Func<T, bool> filter, Func<T, object> orderBy);

    }
}
