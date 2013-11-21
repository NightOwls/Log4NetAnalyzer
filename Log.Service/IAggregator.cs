using System;
using System.Collections.Generic;
using Log.Enum;
using Log.Model;

namespace Log.Service
{
    public interface IAggregator
    {
        IEnumerable<int> GetApplicationErrorAggregate(TimeGroup timeFilter, DateTime fromDate, DateTime toDate);
    }
}
