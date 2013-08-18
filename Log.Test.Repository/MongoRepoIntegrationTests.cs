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

            var mongoRepo = new MongoRepository<LogRecord>();
            mongoRepo.Insert(newLog);

            Assert.IsTrue(newLog.Id != ObjectId.Empty);
        }

        [Test]
        public void TestFind()
        {
            var mongoRepo = new MongoRepository<LogRecord>();
            var result = mongoRepo.Select(x => x.Level, LogLevel.Warn);

            Assert.IsTrue(result.Any());
            Console.WriteLine(result.FirstOrDefault().ToString());
        }
    }
}
