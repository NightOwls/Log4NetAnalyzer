using System;
using System.Diagnostics;
using Log.Data.Mongo;
using Log.Service;
using NUnit.Framework;
using System.Linq;

namespace Log.Test.Service
{
    public class TestAggregator
    {
        [Test, Ignore]
        public void TestGetLogItems()
        {
            var stopwatch = Stopwatch.StartNew();

            var aggregator = new Aggregator(new MongoRepository<Domain.LogRecord>());
            var result = aggregator.GetLogItems("EvilPigeon").ToList();

            stopwatch.Stop();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Logger == "EvilPigeon"));

            Console.WriteLine("Item Count = {0} fetch took: {1}ms", result.Count(), stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void TestGetLogItemAggregate()
        {
            var stopwatch = Stopwatch.StartNew();

            var aggregator = new Aggregator(new MongoRepository<Domain.LogRecord>());
            var result = aggregator.GetLogCountPerApplication().ToList();

            stopwatch.Stop();

            Assert.IsTrue(result.Count() == 6);
            Console.WriteLine("Fetch took {0}ms", stopwatch.ElapsedMilliseconds);

            foreach(var application in result)
            {
                Console.WriteLine(application.GroupItem + " : " + application.Count);
            }
            
        }
    }
}
