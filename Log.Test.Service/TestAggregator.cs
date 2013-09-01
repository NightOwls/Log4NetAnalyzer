using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Log.Data;
using Log.Data.Mongo;
using Log.Domain;
using Log.Ioc;
using Log.Service;
using Moq;
using NUnit.Framework;

namespace Log.Test.Service
{
    public class TestAggregator
    {
       

        [TestFixtureSetUp]
        public void Init()
        {
            var repo = new Mock<IRepository<LogRecord>>();

            repo.Setup(x => x.GetLogAggregate(It.IsAny<string>())).Returns(new List<SimpleAggregate> { new SimpleAggregate {Id = new AggregateId{GroupItem = "Application"}, Count = 100}});
            repo.Setup(x => x.Select(It.IsAny<Expression<Func<LogRecord, bool>>>(), It.IsAny<Expression<Func<LogRecord, object>>>(), It.IsAny<bool>()))
                .Returns(new List<LogRecord>{
                                                new LogRecord() {Logger = "EvilPigeon"}
                                            });

            
            Container.RegisterInstance(repo.Object);

            //probably should mock this out but its just a wrapper around automapper
            Container.Register<IMapping, Mapping>();
            Container.Register<IAggregator, Aggregator>();
        }

        [Test]
        [Category("Unit")]
        public void TestGetLogItems()
        {
            var aggregator = Container.Resolve<IAggregator>();
            var result = aggregator.GetLogItems("EvilPigeon").ToList();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.Logger == "EvilPigeon"));
        }

        [Test]
        [Category("Unit")]
        public void TestGetLogItemAggregate()
        {
            var aggregator = Container.Resolve<IAggregator>();
            var result = aggregator.GetLogCountPerApplication().ToList();

            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.First().GroupItem == "Application");
        }

        [Test]
        [Category("Integration")]
        public void TetsGetApplicationErrorAggregate()
        {
            var aggregator = new Aggregator(new MongoRepository<LogRecord>(), new Mapping());
            var result = aggregator.GetApplicationErrorAggregate().ToList();

            Assert.IsTrue(result.Any());
        }
    }
}
