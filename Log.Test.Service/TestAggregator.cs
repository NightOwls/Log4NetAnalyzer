using System;
using System.Linq;
using Log.Data;
using Log.Data.Mongo;
using Log.Enum;
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
            var repo = new Mock<IAggregationEngine>();

           // repo.Setup(x => x.GetLogAggregate(It.IsAny<string>())).Returns(new List<SimpleAggregate> { new SimpleAggregate {Id = new AggregateId{GroupItem = "Application"}, Count = 100}});
           
            Container.RegisterInstance(repo.Object);

            //probably should mock this out but its just a wrapper around automapper
            Container.Register<IMapping, Mapping>();
            Container.Register<IAggregator, Aggregator>();
        }

        [Test]
        [Category("Integration")]
        public void TetsGetApplicationErrorAggregate()
        {
            var fromDate = new DateTime(2013, 9, 1);
            var toDate = new DateTime(2013, 9, 4);

            var aggregator = new Aggregator(new MongoAggregationEngine(), new Mapping());
            var result = aggregator.GetApplicationErrorAggregate(TimeGroup.Hour, fromDate, toDate).ToList();

            Assert.IsTrue(result.Any());
        }
    }
}
