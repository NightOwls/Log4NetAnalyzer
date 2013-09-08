using System;
using System.Collections.Generic;
using Log.Model;

namespace Log.Service
{
    public interface IAggregator
    {
        IEnumerable<LogAggregate> GetLogCountPerApplication();
        IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate(DateTime fromDate, DateTime toDate);
    }
}
