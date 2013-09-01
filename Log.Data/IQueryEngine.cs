using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Log.Domain;

namespace Log.Data
{
    public interface IQueryEngine
    {
         LogRecord FirstOrDefault(Expression<Func<LogRecord, bool>> filter);
         IEnumerable<LogRecord> Select(Expression<Func<LogRecord, bool>> filter);
         IEnumerable<LogRecord> Select(Expression<Func<LogRecord, bool>> filter, Expression<Func<LogRecord, object>> orderBy, bool descending);
    }
}
