using System;
using log4net;
using NUnit.Framework;

namespace LogGenerator
{
    public class TestGenerator
    {
        #region Private Variables 

        private readonly ILog log = LogManager.GetLogger(typeof(TestGenerator).FullName);

        #endregion 

        #region Switches

        //INCLUDE/EXCLUDE
        private const bool ADD_ERROR_LOGS = true;
        private const bool ADD_ERROR_EX_LOGS = true;
        private const bool ADD_INFO_LOGS = true;
        private const bool ADD_INFO_EX_LOGS = true;
        private const bool ADD_DEBUG_LOGS = true;
        private const bool ADD_DEBUG_EX_LOGS = true;

        //HOW MANY OF EACH 
        private const int NUM_ERROR_LOGS = 10000;
        private const int NUM_ERROR_EX_LOGS = 10000;
        private const int NUM_INFO_LOGS = 10000;
        private const int NUM_INFO_EX_LOGS = 10000;
        private const int NUM_DEBUG_LOGS = 10000;
        private const int NUM_DEBUG_EX_LOGS = 10000;

        //MESSAGES
        private const string ERROR_MSG = "the systen has encounteered an unexpected error ... so FIX IT";
        private const string ERROR_EX_MSG = "null reference error";
        private const string INFO_MSG = "some info for you sir!";
        private const string INFO_EX_MSG = "oh noes! Invalid cast bro!";
        private const string DEBUG_MSG = "we may ave e boouug";
        private const string DEBUG_EX_MSG = "we may ave e boouug";

        #endregion 

        #region Generator

        [Test]
        public void GenerateLogs()
        {
            GenerateErrorLogs();
            GenerateErrorExceptionLogs();
            GenerateInfoLogs();
            GenerateInfoExceptionLogs();
            GenerateDebugLogs();
            GenerateDebugExceptionLogs();
        }

        #endregion

        #region Private Methods 
        
        private void GenerateErrorLogs()
        {

            if (!ADD_ERROR_LOGS) return;

            for (var i = 0; i < NUM_ERROR_LOGS; i++)
            {
                log.Error(ERROR_MSG);
            }
        }
        
        private void GenerateErrorExceptionLogs()
        {
            if (!ADD_ERROR_EX_LOGS) return;

            object obj = null;

            for (var i = 0; i < NUM_ERROR_EX_LOGS; i++)
            {
                try
                {
                    obj.ToString();
                }
                catch (NullReferenceException nex)
                {
                    log.Error(ERROR_EX_MSG, nex);
                }
            }
        }

        private void GenerateInfoLogs()
        {
            if(!ADD_INFO_LOGS) return;

            for (var i = 0; i < NUM_INFO_LOGS; i++)
            {
                log.Info(INFO_MSG);
            }
        }

        private void GenerateInfoExceptionLogs()
        {
            if(!ADD_INFO_EX_LOGS) return;

            object str = "x";

            for (var i = 0; i < NUM_INFO_EX_LOGS; i++)
            {
                try
                {
                    var x = (int)str;
                }
                catch (InvalidCastException icex)
                {
                    log.Info(INFO_EX_MSG, icex);
                }
            }
        }

        private void GenerateDebugLogs()
        {
            if (!ADD_DEBUG_LOGS) return;

            for (var i = 0; i < NUM_DEBUG_LOGS; i++)
            {
                log.Debug(DEBUG_MSG);
            }
        }

        private void GenerateDebugExceptionLogs()
        {

            if (!ADD_DEBUG_EX_LOGS) return;

            for (var i = 0; i < NUM_DEBUG_EX_LOGS; i++)
            {
                try
                {
                    throw new ApplicationException("application has failed miserably");
                }
                catch (ApplicationException aex)
                {
                    log.Debug(DEBUG_EX_MSG, aex);
                }
            }
        }

        #endregion

    }
}
