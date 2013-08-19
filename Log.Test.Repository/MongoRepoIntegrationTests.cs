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
        private MongoRepository<LogRecord> mongoRepo;

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
            var result = mongoRepo.Select(x => x.Logger == "Log.Test.Generator.TestGenerator");

            Assert.IsTrue(result.Any());
            Console.WriteLine(result.First().Message);
        }

        [Test]
        public void TestSelect()
        {

            var result = mongoRepo.Select(x => ((int)x.Level) == 0).ToList();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Level == 0));
        }

        [Test] public void TestSelectOrdered()
        {
            
        }
    }
}
