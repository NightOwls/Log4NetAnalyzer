using System;
using System.Collections.Generic;
using System.Linq;
using Log.Domain;
using Log.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Log.Data.Mongo
{
    public class MongoAggregationEngine : MongoDataAdapter<LogRecord>, IAggregationEngine
    {
        #region Public Methods 

        public IEnumerable<ApplicationErrorAggregate> GetApplicationErrorAggregate(TimeGroup timeFilter, DateTime fromDate, DateTime toDate)
        {
            var match = new BsonDocument
                            {
                                {
                                    "$match", new BsonDocument
                                                    {
                                                        {
                                                            "LogTime", new BsonDocument
                                                                            {
                                                                                {"$gt", fromDate},
                                                                                {"$lt", toDate}
                                                                            }
                                                        }
                                                    }
                                 }
                            };

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

            var sort = new BsonDocument {{"$sort", new BsonDocument{{"Application", 1}}}};

            return GetAggregate<ApplicationErrorAggregate>(new[] { match, group1, group2, project, sort});
        }

        #endregion

        #region Private Methods

        private IEnumerable<TK> GetAggregate<TK>(BsonDocument[] pipeline)
        {
            var result = MongoCollection.Aggregate(pipeline)
                .ResultDocuments
                .Select(BsonSerializer.Deserialize<TK>);

            return result;
        }

        #endregion
    }
}
