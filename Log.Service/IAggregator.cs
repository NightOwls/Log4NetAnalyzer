using System;
using System.Collections.Generic;
using Log.Enum;
using Log.Model;

namespace Log.Service
{
    public interface IAggregator
    {
        IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate(TimeGroup timeFilter, DateTime fromDate, DateTime toDate);
    }
}
