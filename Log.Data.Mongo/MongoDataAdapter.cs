using System.Configuration;
using Log.Domain;
using MongoDB.Driver;

namespace Log.Data.Mongo
{
    public class MongoDataAdapter<T> where T : EntityBase
    {
         #region Private Variables 

        private readonly MongoServer mongoServer;
        private readonly MongoDatabase mongoDatabase;
        private readonly MongoCollection<T> mongoCollection;
        
        #endregion 
        
        #region Protected Properties 

        protected MongoCollection<T> MongoCollection { get { return mongoCollection; } }

        #endregion

        #region Constructors

        public MongoDataAdapter()
        {
            var connectionString = ConfigurationManager.AppSettings["mongoServer"];
            var dbName = ConfigurationManager.AppSettings["mongoDbName"];

            var mongoClient = new MongoClient(connectionString);
            mongoServer = mongoClient.GetServer();
            mongoDatabase = mongoServer.GetDatabase(dbName);
            mongoCollection = mongoDatabase.GetCollection<T>(typeof(T).FullName);
        } 

        #endregion
    }
}
