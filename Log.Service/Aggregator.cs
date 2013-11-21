using System;
using System.Collections.Generic;
using System.Linq;
using Log.Data;
using Log.Enum;

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

        public IEnumerable<int> GetApplicationErrorAggregate(TimeGroup timefilter, DateTime fromDate, DateTime toDate)
        {
            var domainResult = aggregationEngine.GetApplicationErrorAggregate(timefilter, fromDate, toDate).ToList();
			//return domainResult.Select(mapping.Map<Domain.ApplicationErrorAggregate, Model.ApplicationErrorAggregate>);
			return new List<int> ();
        }

        #endregion
    }
}
