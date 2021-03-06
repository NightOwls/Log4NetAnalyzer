﻿using System;
using Log.Data.Mongo;
using Log.Domain;
using log4net.Appender;
using log4net.Core;
using System.Linq;
using Log.Enum;

namespace Log.Test.Generator
{
    /// <summary>
    /// Really only for internal testing use. All external appenders should log to a service interface rather than directly to the database 
    /// </summary>
    public class MongoAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            var newLog = new LogRecord
                             {
                                 Level =  GetLogLevel(loggingEvent.Level),
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
            return System.Enum.TryParse(level.Name, true, out logLevel) ? logLevel : LogLevel.Debug;
        }
    }
}
