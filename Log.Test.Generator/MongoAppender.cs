using System;
using Log.Data.Mongo;
using Log.Domain;
using log4net.Appender;
using log4net.Core;
using System.Linq;

namespace Log.Test.Generator
{
    public class MongoAppender : AppenderSkeleton
    {
        //Really only for internal testing use. All external appenders should log to a service interface rather than directly to the database 

        protected override void Append(LoggingEvent loggingEvent)
        {
            var level = LogLevel.Debug;
            Enum.TryParse(loggingEvent.Level.DisplayName, true, out level);

            var newLog = new LogRecord
                             {
                                 Level =  level,
                                 LogTime = loggingEvent.TimeStamp,
                                 Logger = loggingEvent.LoggerName,
                                 Thread = loggingEvent.ThreadName,
                                 Message = loggingEvent.MessageObject.ToString(),
                                 Exception =  loggingEvent.GetExceptionString(),
                                 
                                 ClassName = loggingEvent.LocationInformation.ClassName,
                                 FileName = loggingEvent.LocationInformation.FileName,
                                 MethodName = loggingEvent.LocationInformation.MethodName,
                                 LineNumber = loggingEvent.LocationInformation.LineNumber,
                                 CallStack = loggingEvent.LocationInformation.StackFrames.Select(x => x.ToString())
                                                                             .Aggregate((a, b) => string.Format("{0}{1}{2}", a, Environment.NewLine, b))
                             };

            var repo = new MongoRepository<LogRecord>();
            repo.Insert(newLog);
        }

        private static LogLevel GetLogLevel(Level level)
        {
            LogLevel logLevel;
            return Enum.TryParse(level.Name, out logLevel) ? logLevel : LogLevel.Debug;
        }
    }
}
