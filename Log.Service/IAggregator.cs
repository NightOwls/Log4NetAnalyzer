using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Model;

namespace Log.Service
{
    public interface IAggregator
    {
        IEnumerable<LogItem> GetLogItems(string applicationName);
        IEnumerable<LogAggregate> GetLogCountPerApplication();
        IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate();

    }
}
