using System.Collections.Generic;
using System.Linq;
using Log.Data;
using Log.Domain;
using Log.Model;

namespace Log.Service
{
    public class Aggregator : IAggregator
    {
        #region Private Variables 

        private readonly IAggregationEngine aggregationEngine;
        private readonly IMapping mapping;

        #endregion

        #region Constructors

        public Aggregator(IAggregationEngine aggregationEngine, IMapping mapping)
        {
            this.aggregationEngine = aggregationEngine;
            this.mapping = mapping;
        } 

        #endregion

        #region Public Methods 

        public IEnumerable<LogAggregate> GetLogCountPerApplication()
        {
            var domainResult = aggregationEngine.GetLogAggregate("Logger");
            return domainResult.Select(mapping.Map<SimpleAggregate, LogAggregate>);
        } 

        public IEnumerable<Model.ApplicationErrorAggregate> GetApplicationErrorAggregate()
        {
            var domainResult = aggregationEngine.GetApplicationErrorAggregate().ToList();
            return domainResult.Select(mapping.Map<Domain.ApplicationErrorAggregate, Model.ApplicationErrorAggregate>);
        }

        #endregion
    }
}
