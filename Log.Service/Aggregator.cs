using System;
using System.Collections.Generic;
using System.Linq;
using Log.Data;
using Log.Data.Mongo;
using Log.Domain;
using Log.Model;
using LogLevel = Log.Model.LogLevel;

namespace Log.Service
{
    public class Aggregator : IAggregator
    {
        #region Private Variables 

        private readonly IRepository<LogRecord> repository;
        private readonly IMapping mapping;

        #endregion

        #region Constructors

        public Aggregator(IRepository<LogRecord> repository, IMapping mapping)
        {
            this.repository = repository;
            this.mapping = mapping;
        } 

        #endregion

        public IEnumerable<LogAggregate> GetLogCountPerApplication()
        {
            var domainResult = repository.GetLogAggregate("Logger");
            return domainResult.Select(mapping.Map<SimpleAggregate, LogAggregate>);
        } 

        public IEnumerable<LogItem> GetLogItems(string applicationName)
        {
            return repository.Select(x => x.Logger.ToLower() == applicationName.ToLower(), x => x.LogTime, true).Select(mapping.Map<LogRecord, LogItem>);
        }
    }
}
