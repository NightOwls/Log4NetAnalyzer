using System;
using System.Diagnostics;
using System.Linq;
using Log.Data.Mongo;
using Log.Domain;
using MongoDB.Bson;
using NUnit.Framework;

namespace Log.Test.Repository
{
    public class MongoRepoIntegrationTests
    {
        #region Private variables 

        private MongoRepository<LogRecord> mongoRepo;

        #endregion

        #region Setup/Teardown

        [TestFixtureSetUp]
        public void Init()
        {
            mongoRepo = new MongoRepository<LogRecord>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            mongoRepo = null;
        }

        #endregion

        #region Tests

        [Test]
        public void TestInsert()
        {
            var newLog = new LogRecord
                             {
                                 Level = LogLevel.Warn,
                                 Message = "some error message",
                                 Logger = "Test.Logger",
                                 LogTime = DateTime.Now,
                                 Thread = "1",
                             };

            Assert.IsTrue(newLog.Id == ObjectId.Empty);

            var stopwatch = Stopwatch.StartNew();

            mongoRepo.Insert(newLog);

            stopwatch.Stop();
            
            Assert.IsTrue(newLog.Id != ObjectId.Empty);

            Console.WriteLine("Insert took : {0}ms", stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void TestFind()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = mongoRepo.Select(x => x.Logger == "EvilPigeon" && x.Exception == string.Empty).ToList();

            stopwatch.Stop();
           
            Assert.IsTrue(result.Any());
            Console.WriteLine(result.First().Message);
            Console.WriteLine("Fetch took : {0}ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("{0} records returned", result.Count);
        }

        [Test]
        public void TestSelect()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = mongoRepo.Select(x => x.Level == LogLevel.Debug && x.Exception == string.Empty).ToList();
            
            stopwatch.Stop();
           
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Level == LogLevel.Debug));

            Console.WriteLine("Fetch took : {0}ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("{0} records returned", result.Count);
        }

        [Test]
        public void TestSelectOrdered()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = mongoRepo.Select(x => x.Level == LogLevel.Fatal && x.Exception == string.Empty, x => x.LogTime, true).ToList();

            stopwatch.Stop();
            
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Level == LogLevel.Fatal));
            Assert.IsTrue(result.All(x => x.Exception == string.Empty));
            Assert.IsTrue(result.First().LogTime == result.Max(x => x.LogTime));
            Assert.IsTrue(result.Last().LogTime == result.Min(x => x.LogTime));

            Console.WriteLine("Fetch took : {0}ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("{0} records returned", result.Count);
        }

        #endregion
    }
}
