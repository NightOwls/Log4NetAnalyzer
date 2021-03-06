﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Log.Enum;
using log4net;
using NUnit.Framework;

namespace Log.Test.Generator
{
    public class TestGenerator
    {
        #region Private Variables 

        private readonly ILog billSplitsLog = LogManager.GetLogger("BillSplits");
        private readonly ILog easterHuntLog = LogManager.GetLogger("EasterHunt");
        private readonly ILog shapeMatcherLog = LogManager.GetLogger("ShapeMatcher");
        private readonly ILog cafeCoderLog = LogManager.GetLogger("CafeCoder");
        private readonly ILog evilPigeonLog = LogManager.GetLogger("EvilPigeon");
        private readonly ILog codeFrenzyLog = LogManager.GetLogger("CodeFrenzy");
        private readonly ILog iDevForFunLog = LogManager.GetLogger("iDevForFun");

        private List<ILog> loggerList;

        #endregion 

        #region Switches

        //INCLUDE/EXCLUDE
        private const bool ADD_DEBUG_LOGS = true;
        private const bool ADD_DEBUG_EX_LOGS = true;
        private const bool ADD_INFO_LOGS = true;
        private const bool ADD_INFO_EX_LOGS = true;
        private const bool ADD_WARN_LOGS = true;
        private const bool ADD_WARN_EX_LOGS = true;
        private const bool ADD_ERROR_LOGS = true;
        private const bool ADD_ERROR_EX_LOGS = true;
        private const bool ADD_FATAL_LOGS = true;
        private const bool ADD_FATAL_EX_LOGS = true;

        //HOW MANY OF EACH 
        
        //MAKE THIS GREATER THAN 0 TO SET THE NUMBER OF LOGS PER TYPE IN ONE GO 
        private const int DEFAULT_NUM_LOGS = 100000;

        //OTHERWISE SET THEM ONE BY ONE 
        private const int NUM_DEBUG_LOGS =    DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 50000;
        private const int NUM_DEBUG_EX_LOGS = DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 40000;
        private const int NUM_INFO_LOGS =     DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 60000;
        private const int NUM_INFO_EX_LOGS =  DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 55000;
        private const int NUM_WARN_LOGS =     DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 40000;
        private const int NUM_WARN_EX_LOGS =  DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 40000;
        private const int NUM_ERROR_LOGS =    DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 30000;
        private const int NUM_ERROR_EX_LOGS = DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 55000;
        private const int NUM_FATAL_LOGS =    DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 30000;
        private const int NUM_FATAL_EX_LOGS = DEFAULT_NUM_LOGS > 0 ? DEFAULT_NUM_LOGS : 45000;

        //MESSAGES
        private const string DEBUG_MSG = "we may ave e boouug";
        private const string DEBUG_EX_MSG = "we may ave en exceptional boouug";
        private const string INFO_MSG = "some info for you sir!";
        private const string INFO_EX_MSG = "ahhh neeeew! Ets en envelid cast brew!";
        private const string WARN_MSG = "Warning ... DANGER Will Robinson ... Warning";
        private const string WARN_EX_MSG = "Warning ... EXCEPTIONAL DANGER Will Robinson ... Warning";
        private const string ERROR_MSG = "the system has encounteered an unexpected error ... so FIX IT";
        private const string ERROR_EX_MSG = "is it a bird? is it a plane? no ... its nothing ... and thats the problem";
        private const string FATAL_MSG = "THE WEB SERVER IS DOWWWWWWWNNNN";
        private const string FATAL_EX_MSG = "THE WEB SERVER IS DOWWWWWWWNNNN AND SOMETHING KILLED IT";

        #endregion 

        #region Setup/Teardown

        [TestFixtureSetUp]
        public void Init()
        {
            loggerList = new List<ILog>
                             {
                                 billSplitsLog,
                                 easterHuntLog,
                                 shapeMatcherLog,
                                 cafeCoderLog,
                                 evilPigeonLog,
                                 codeFrenzyLog,
                                 iDevForFunLog
                             };
        }

        #endregion

        #region Generator

        [Test]
        public void GenerateLogs()
        {
            var stopwatch = Stopwatch.StartNew();

            WriteLog(LogLevel.Debug, NUM_DEBUG_LOGS, DEBUG_MSG);
            WriteLog(LogLevel.Debug, NUM_DEBUG_EX_LOGS, DEBUG_EX_MSG, GenerateInvalidCastException());
            WriteLog(LogLevel.Info, NUM_INFO_LOGS, INFO_MSG);
            WriteLog(LogLevel.Info, NUM_INFO_EX_LOGS, INFO_EX_MSG, GenerateApplicationException());
            WriteLog(LogLevel.Warn, NUM_WARN_LOGS, WARN_MSG);
            WriteLog(LogLevel.Warn, NUM_WARN_EX_LOGS, WARN_EX_MSG, GenerateInvalidCastException());
            WriteLog(LogLevel.Error, NUM_ERROR_LOGS, ERROR_MSG);
            WriteLog(LogLevel.Error, NUM_ERROR_EX_LOGS, ERROR_EX_MSG, GenerateNullReferenceException());
            WriteLog(LogLevel.Fatal, NUM_FATAL_LOGS, FATAL_MSG);
            WriteLog(LogLevel.Fatal, NUM_FATAL_EX_LOGS, FATAL_EX_MSG, GenerateNullReferenceException());

            stopwatch.Stop();

            Debug.WriteLine("Insert took {0}s", stopwatch.ElapsedMilliseconds/1000);
        }

        #endregion

        #region Private Methods 
        
        private NullReferenceException GenerateNullReferenceException()
        {
            object obj = null;
            
            try
            {
                obj.ToString();
            }
            catch (NullReferenceException nex)
            {
                return nex;
            }
            return null;
        }

        private InvalidCastException GenerateInvalidCastException()
        {
            object str = "x";

            try
            {
                var x = (int)str;
            }
            catch (InvalidCastException icex)
            {
                return icex;
            }

            return null;
        }

        private ApplicationException GenerateApplicationException()
        {
            return new ApplicationException("application has failed miserably");
        }

        private void WriteLog(LogLevel level, int numLogs, string message)
        {
            WriteLog(level, numLogs, message, null);
        }

        private void WriteLog(LogLevel level, int numLogs, string message, Exception ex)
        {
            for(var i = 0; i < numLogs; i++)
            {
                var log = GetRandomLogger();

                switch (level)
                {
                    case LogLevel.Debug:
                        if (ex == null && ADD_DEBUG_LOGS) log.Debug(message);
                        if (ex != null && ADD_DEBUG_EX_LOGS) log.Debug(message, ex);
                        break;
                    case LogLevel.Info:
                        if (ex == null && ADD_INFO_LOGS) log.Info(message);
                        if (ex != null && ADD_INFO_EX_LOGS) log.Info(message, ex);
                        break;
                    case LogLevel.Warn:
                        if(ex == null && ADD_WARN_LOGS) log.Warn(message);
                        if(ex!= null && ADD_WARN_EX_LOGS) log.Warn(message, ex);
                        break;
                    case LogLevel.Error:
                        if(ex == null && ADD_ERROR_LOGS) log.Error(message);
                        if(ex!= null && ADD_ERROR_EX_LOGS) log.Error(message, ex);
                        break;
                   case LogLevel.Fatal:
                       if(ex == null && ADD_FATAL_LOGS) log.Fatal(message);
                        if(ex!= null && ADD_FATAL_EX_LOGS) log.Fatal(message, ex);
                        break;

                }
            }
        }

        private ILog GetRandomLogger()
        {
            var rnd = new Random();
            var loggerIndex = rnd.Next(0, loggerList.Count - 1);
            return loggerList[loggerIndex];
        }   

        #endregion

    }
}
