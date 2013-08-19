using System;
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

            mongoRepo.Insert(newLog);

            Assert.IsTrue(newLog.Id != ObjectId.Empty);
        }

        [Test]
        public void TestFind()
        {
            var result = mongoRepo.Select(x => x.Logger == "Log.Test.Generator.TestGenerator").ToList();

            Assert.IsTrue(result.Any());
            Console.WriteLine(result.First().Message);
        }

        [Test]
        public void TestSelect()
        {
            var result = mongoRepo.Select(x => x.Level == LogLevel.Debug).ToList();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Level == LogLevel.Debug));
        }

        [Test]
        public void TestSelectOrdered()
        {
            var result = mongoRepo.Select(x => x.Level == LogLevel.Fatal && x.Exception == string.Empty, x => x.LogTime, true).ToList();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Level == LogLevel.Fatal));
            Assert.IsTrue(result.All(x => x.Exception == string.Empty));
            Assert.IsTrue(result.First().LogTime == result.Max(x => x.LogTime));
            Assert.IsTrue(result.Last().LogTime == result.Min(x => x.LogTime));
        }

        #endregion
    }
}
