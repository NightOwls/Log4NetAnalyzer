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

        private readonly IRepository<Domain.LogRecord> repository; 

        #endregion

        #region Constructors

        public Aggregator(IRepository<Domain.LogRecord> repository)
        {
            this.repository = repository;
        } 

        #endregion

        public IEnumerable<LogAggregate> GetLogCountPerApplication()
        {
            var domainResult = repository.GetLogAggregate("Logger");
           return domainResult.Select(Mapping.Map<SimpleAggregate, LogAggregate>);
            
        } 

        public IEnumerable<LogItem> GetLogItems(string applicationName)
        {
            return repository.Select(x => x.Logger.ToLower() == applicationName.ToLower(), x => x.LogTime, true).Select(Mapping.Map<LogRecord, LogItem>);
        }
    }
}
