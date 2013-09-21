using System;
using System.Collections.Generic;
using Log.Domain;
using Log.Enum;

namespace Log.Data
{
    public interface IAggregationEngine
    {
        IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate(TimeGroup timeFilter, DateTime fromDate, DateTime toDate);
    }
}
