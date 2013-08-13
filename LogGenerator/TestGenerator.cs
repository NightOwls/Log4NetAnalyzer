using System;
using log4net;
using NUnit.Framework;

namespace LogGenerator
{
    public class TestGenerator
    {
        private readonly ILog log = LogManager.GetLogger(typeof(TestGenerator).FullName);

        [Test]
        public void GenerateErrorLogs()
        {
            for(var i = 0; i < 10; i++)
            {
                log.Error("errorLog", new Exception("Some exception message"));
            }
        }

    }
}
