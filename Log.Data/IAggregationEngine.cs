using System;
using System.Collections.Generic;
using Log.Domain;

namespace Log.Data
{
    public interface IAggregationEngine
    {
        IEnumerable<SimpleAggregate> GetLogAggregate(string groupByProperty);
        IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate(DateTime fromDate, DateTime toDate);
    }
}
