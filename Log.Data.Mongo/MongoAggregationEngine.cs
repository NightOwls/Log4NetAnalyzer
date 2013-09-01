using System.Collections.Generic;
using System.Linq;
using Log.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Log.Data.Mongo
{
    public class MongoAggregationEngine : MongoDataAdapter<LogRecord>, IAggregationEngine
    {
        #region Public Methods 

        public IEnumerable<SimpleAggregate> GetLogAggregate(string groupByProperty)
        {
            var bson = new BsonDocument
                           {
                                {
                                   "$group",
                                   new BsonDocument
                                       {
                                           {
                                               "_id", new BsonDocument
                                                          {
                                                              {
                                                                  "GroupItem", "$" + groupByProperty
                                                              }
                                                          }

                                           },
                                           {
                                               "Count", new BsonDocument
                                                            {
                                                                {
                                                                    "$sum", 1
                                                                }
                                                            }
                                           }
                                       }
                                   }
                           };

            return GetAggregate<SimpleAggregate>(new[] { bson });
        }

        public IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate()
        {
            var group1 = new BsonDocument
                           {
                                {
                                   "$group", new BsonDocument
                                               {
                                                   {
                                                       "_id", new BsonDocument
                                                                  {
                                                                      {"Application", "$Logger"},
                                                                      {"Level", "$Level"}
                                                                  }

                                                   },
                                                   {
                                                       "Count", new BsonDocument
                                                                    {
                                                                        {"$sum", 1}
                                                                    }
                                                   }
                                               }
                                   }
                           };

            var group2 = new BsonDocument
                             {
                                 {
                                     "$group", new BsonDocument
                                                   {
                                                       {
                                                           "_id", new BsonDocument
                                                                      {
                                                                          {"Application", "$_id.Application"}
                                                                      }
                                                       },
                                                       {
                                                           "Errors", new BsonDocument
                                                                         {
                                                                             {
                                                                                 "$push", new BsonDocument
                                                                                              {
                                                                                                  {"Level", "$_id.Level"},
                                                                                                  {"Count", "$Count"}
                                                                                              }
                                                                             }
                                                                         }
                                                       }
                                                       
                                                   }
                                 }
                             };

            var project = new BsonDocument
                              {
                                  {
                                      "$project",
                                      new BsonDocument
                                          {
                                              {"_id", 0},
                                              {"Application", "$_id.Application"},
                                              {"Errors", "$Errors"}
                                          }
                                  }
                              };

            return GetAggregate<ApplicationErrorAggregate>(new[] { group1, group2, project });
        }

        #endregion

        #region Private Methods

        private IEnumerable<TK> GetAggregate<TK>(BsonDocument[] pipeline)
        {
            var result = mongoCollection.Aggregate(pipeline)
                .ResultDocuments
                .Select(BsonSerializer.Deserialize<TK>);

            return result;
        }

        #endregion
    }
}
