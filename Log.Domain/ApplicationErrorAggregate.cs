using System.Collections.Generic;

namespace Log.Domain
{
    public class ApplicationErrorAggregate
    {
          public string Application { get; set; }
          public IEnumerable<LogCount> Errors { get; set; } 
    }

    public class LogCount
    {
        public LogLevel Level { get; set; }
        public int Count { get; set; }
    }
   
}
