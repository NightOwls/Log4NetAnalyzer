using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;
using Log.Domain;
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

        public T First(Expression<Func<T, bool>> filter)
        {
            if(filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            var query = Query<T>.Where(filter);
            var result = mongoCollection.FindOneAs<T>(query);

            if(result == null)
            {
                throw new InvalidOperationException(string.Format("object {0} not found", typeof(T)));
            }

            return result;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            var query = Query<T>.Where(filter);
            return mongoCollection.FindOneAs<T>(query);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> filter)
        {
            var query = Query<T>.Where(filter);
            return mongoCollection.FindAs<T>(query);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, bool descending)
        {
            var query = Query<T>.Where(filter);
            var sort = descending ? SortBy<T>.Descending(orderBy) : SortBy<T>.Ascending(orderBy);
            return mongoCollection.FindAs<T>(query).SetSortOrder(sort);
        }

        public void Update(T entity)
        {
            mongoCollection.Save(entity);
        }

        #endregion
    }
}
