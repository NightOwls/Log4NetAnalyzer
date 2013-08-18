using System;

namespace Log.Domain
{
    public class LogRecord : EntityBase
    {
        public DateTime LogTime { get; set; }
        public string Thread { get; set; }
        public LogLevel Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

        public string ClassName { get; set; }
        public string FileName { get; set; }
        public string LineNumber { get; set; }
        public string MethodName { get; set; }
        public string CallStack { get; set; }
    }
}
