using System.Collections.Generic;
using Log.Enum;

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
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }
   
}
