using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TemperatureMonitor.Persistence.Domain;
using TemperatureMonitor.Persistence.Repositories;

namespace TemperatureMonitor.Persistence.MongoDb.Repositories
{

    /// <inheritdoc />
    public class Repository<T> : IRepository<T> where T : Document
    {

        private readonly IMongoCollection<T> _mongoCollection;


        /// <inheritdoc />
        protected Repository(MongoContext context, string collectionName)
        {
            _mongoCollection = context.GetCollection<T>(collectionName);
        }


        /// <inheritdoc />
        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).FirstOrDefaultAsync();
        }


        /// <inheritdoc />
        public Task<List<T>> GetAllAsync()
        {
            return _mongoCollection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }


        /// <inheritdoc />
        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _mongoCollection.Find(predicate).ToListAsync().ConfigureAwait(false);
        }


        /// <inheritdoc />
        public Task AddAsync(T document)
        {
            return _mongoCollection.InsertOneAsync(document);
        }


        /// <inheritdoc />
        public Task AddAsync(IEnumerable<T> documents)
        {
            return _mongoCollection.InsertManyAsync(documents);
        }


        /// <inheritdoc />
        public Task<DeleteResult> RemoveAsync(ObjectId objectId)
        {
            return _mongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }


        /// <inheritdoc />
        public Task<DeleteResult> RemoveAsync(IEnumerable<ObjectId> objectIds)
        {
            return _mongoCollection.DeleteManyAsync(Builders<T>.Filter.In("_id", objectIds));
        }


        /// <inheritdoc />
        public Task UpdateValueAsync(Expression<Func<T, object>> predicateSearch, object searchValue, Expression<Func<T, object>> predicateNew, object newValue)
        {
            var filter = Builders<T>.Filter.Eq(predicateSearch, searchValue);
            var update = Builders<T>.Update.Set(predicateNew, newValue);
            return _mongoCollection.FindOneAndUpdateAsync(filter, update);
        }


        /// <inheritdoc />
        public Task UpdateValueAsync(ObjectId objectId, Expression<Func<T, object>> predicateNew, object newValue)
        {
            var filter = Builders<T>.Filter.Eq(x => x.BsonObjectId, objectId);
            var update = Builders<T>.Update.Set(predicateNew, newValue);
            return _mongoCollection.FindOneAndUpdateAsync(filter, update);
        }


        /// <inheritdoc />
        public Task<List<T>> GetLastDocumentsAsync(int count)
        {
            return _mongoCollection.AsQueryable().OrderByDescending(x => x.AddedAtUtc).Take(count).ToListAsync();
        }


        /// <inheritdoc />
        public Task<T> GetLastDocumentAsync()
        {
            return _mongoCollection.AsQueryable().OrderByDescending(x => x.AddedAtUtc).Take(1).FirstOrDefaultAsync();
        }


        /// <inheritdoc />
        public Task<long> DocumentCountAsync()
        {
            return _mongoCollection.EstimatedDocumentCountAsync();
        }


        /// <inheritdoc />
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            var docCount = await _mongoCollection.CountDocumentsAsync(predicate).ConfigureAwait(false);
            return docCount > 0;
        }
    }
}
