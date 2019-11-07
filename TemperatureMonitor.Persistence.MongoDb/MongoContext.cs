using System;
using MongoDB.Driver;

namespace TemperatureMonitor.Persistence.MongoDb
{

    /// <summary>
    /// Hold the connection to the database.
    /// </summary>
    public class MongoContext : BaseMongoContext
    {

        private readonly IMongoDatabase _database;


        /// <summary>
        /// Creates a new <see cref="MongoContext"/>.
        /// </summary>
        public MongoContext()
        {
            var connectionString = DatabaseConfig.Data.ConnectionString;
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(connectionString);

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("RoomTemperature");
        }


        /// <summary>
        /// Creates a new <see cref="MongoContext"/>.
        /// </summary>
        /// <param name="connectionString">The connection string that will be used to connect to the Database.</param>
        public MongoContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("RoomTemperature");
        }


        /// <summary>
        /// Creates a new <see cref="MongoContext"/>.
        /// </summary>
        /// <param name="connectionString">The connection string that will be used to connect to the Database.</param>
        /// <param name="databaseName">The name of the database.</param>
        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }


        /// <summary>
        /// Get a <see cref="IMongoCollection{TDocument}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IMongoCollection{TDocument}"/>.</typeparam>
        /// <param name="collectionName">The name of the <see cref="IMongoCollection{TDocument}"/>.</param>
        /// <returns>Returns the requested <see cref="IMongoCollection{TDocument}"/>.</returns>
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
