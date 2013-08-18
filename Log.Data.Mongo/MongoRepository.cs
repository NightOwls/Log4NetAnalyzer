using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;
using Log.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Log.Data.Mongo
{
    public class MongoRepository<T> : IRepository<T>
        where T : EntityBase
    {
        #region Private Variables 

        private readonly MongoServer mongoServer;
        private readonly MongoDatabase mongoDatabase;
        private readonly MongoCollection<T> mongoCollection;
        
        #endregion 
        
        #region Constructors

        public MongoRepository()
        {
            var connectionString = ConfigurationManager.AppSettings["mongoServer"];
            var dbName = ConfigurationManager.AppSettings["mongoDbName"];

            var mongoClient = new MongoClient(connectionString);
            mongoServer = mongoClient.GetServer();
            mongoDatabase = mongoServer.GetDatabase(dbName);
            mongoCollection = mongoDatabase.GetCollection<T>(typeof(T).FullName);
        } 

        #endregion

        #region Public Methods

        public T Insert(T entity)
        {
            if(entity == null) throw new NullReferenceException(string.Format("Entity cannot be null: {0}", typeof(T)));

            var result = mongoCollection.Insert(entity);
            
            if(result.HasLastErrorMessage)
            {
                throw new DataException(string.Format("Insert failed: {0}, object: {1}", result.ErrorMessage, entity));
            }

            return entity;
        }

        public T First(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select<TMember>(Expression<Func<T, TMember>> filter, TMember value)
        {
            var query = Query<T>.EQ(filter, value);
            return mongoCollection.FindAs<T>(query);
        }

       // public IEnumerable<T> Select(Func<T, bool> filter, Func<T, object> orderBy)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        #endregion 
    }
}
