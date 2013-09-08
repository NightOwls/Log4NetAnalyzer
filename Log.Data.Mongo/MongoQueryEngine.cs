using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Log.Domain;

namespace Log.Data.Mongo
{
    public class MongoQueryEngine : IQueryEngine
    {
        #region Private Variables 

        private readonly IRepository<LogRecord> repository;

        #endregion

        #region Constructors

        public MongoQueryEngine(IRepository<LogRecord> repository)
        {
            this.repository = repository;
        }

        #endregion
        
        #region Public Methods

        public LogRecord FirstOrDefault(Expression<Func<LogRecord, bool>> filter)
        {
            return repository.FirstOrDefault(filter);
        }

        public IEnumerable<LogRecord> Select(Expression<Func<LogRecord, bool>> filter)
        {
            return repository.Select(filter);
        }

        public IEnumerable<LogRecord> Select(Expression<Func<LogRecord, bool>> filter, Expression<Func<LogRecord, object>> orderBy, bool descending)
        {
            return repository.Select(filter, orderBy, descending);
        }

        #endregion
    }
}
