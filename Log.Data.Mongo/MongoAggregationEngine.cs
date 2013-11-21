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

            var project1 = new BsonDocument
                               {
                                   {
                                       "$project", new BsonDocument
                                                       {
                                                           {"_id", "$_id"},
                                                           {"Logger", "$Logger"},
                                                           {"Level", "$Level"},
                                                           {"hour", new BsonDocument {{"hour", "$LogTime"}}},
                                                           {"day", new BsonDocument {{"dayOfMonth", "$LogTime"}}},
                                                           {"month", new BsonDocument {{"month", "$LogTime"}}},
                                                           {"year", new BsonDocument {{"year", "$LogTime"}}}
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
                                                                           {"groupItem", "$Logger"},
                                                                           //{"level", "$Level"}, - total number of errors 
                                                                           {"hour", "$hour"},
                                                                           {"day", "$day"},
                                                                           {"month", "$month"},
                                                                           {"year", "$year"}
                                                                       }
                                                        },
                                                        {
                                                            "Count", new BsonDocument
                                                                        {
                                                                            {"$sum", 1}
                                                                        }
                                                        }
                                                    }
                                },
                             };
            

            var group2 = new BsonDocument
                           {
                                {
                                   "$group", new BsonDocument
                                                   {
			                                            { 
                                                            "_id", new BsonDocument 
                                                                    {
						                                                 {"groupItem", "$_id.groupItem"},
					                                                }
                                                        },
                                                        {
				                                            "Errors", new BsonDocument
					                                                    {
							                                                { 
                                                                                "$push", new BsonDocument
                                                                                            {
									                                                            //{"Level", "$_id.level"}, 
									                                                            {"Hour", "$_id.hour"}, 
									                                                            {"Day", "$_id.day"}, 
									                                                            {"Month", "$_id.month"}, 
									                                                            {"Year", "$_id.year"}, 
									                                                            {"Count", "$Count"}
								                                                            }
					                                                        }
			                                                            }
                                                        }
                                                   }
                                }
                           };
           
            var project2 = new BsonDocument
                              {
                                  {
                                      "$project",
                                      new BsonDocument
                                          {
                                              {"_id", 0},
                                              {"Application", "$_id.groupItem"},
                                              {"Errors", "$Errors"}
                                          }
                                  }
                              };

            var sort = new BsonDocument {{"$sort", new BsonDocument{{"Application", 1}}}};

            return GetAggregate<ApplicationErrorAggregate>(new[] { match, project1, group1, group2, project2, sort });  
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
