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

        //NULL REFERENCE EXCEPTION ERROR LOGS
        private const bool ADD_NULL_REF_LOGS = true;
        private const int NUM_NULL_REF_LOGS = 100;
        private const string NULL_REF_MSG = "null reference error";

        //INFO LOGS
        private const bool ADD_INFO_LOGS = true;
        private const int NUM_INFO_LOGS = 100;
        private const string INFO_MSG = "some info for you sir!";

        //INVALID CAST EXCEPTION INFO LOGS 
        private const bool ADD_INFO_EX_LOGS = true;
        private const int NUM_INFO_EX_LOGS = 100;
        private const string INFO_EX_MSG = "some info for you sir!";

        #endregion 

        #region Generator

        [Test]
        public void GenerateLogs()
        {
            GenerateNullReferenceLogs();
            GenerateInfoLogs();
            GenerateInfoExceptionLogs();
        }

        #endregion

        #region Private Methods 

        private void GenerateNullReferenceLogs()
        {
            if (!ADD_NULL_REF_LOGS) return;

            object obj = null;

            for (var i = 0; i < NUM_NULL_REF_LOGS; i++)
            {
                try
                {
                    obj.ToString();
                }
                catch (NullReferenceException nex)
                {
                    log.Error(NULL_REF_MSG, nex);
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

        #endregion

    }
}
