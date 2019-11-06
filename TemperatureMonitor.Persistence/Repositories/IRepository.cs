using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TemperatureMonitor.Persistence.Repositories
{

    /// <summary>
    /// This is a generic Repository that should be used in all table/collection specific Repositories.
    /// </summary>
    /// <typeparam name="T">The object type of the table/collection</typeparam>
    public interface IRepository<T> where T : class
    {

        /// <summary>
        /// Get all rows/documents for the table/collection.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous get operation.
        /// The task result contains the requested <list type="T"></list>"/>.
        /// </returns>
        Task<List<T>> GetAllAsync();


        /// <summary>
        /// Find a rows/documents in the table/collection.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression"/> that will be used to look for the row/document.</param>
        /// <returns>
        /// A task that represents the asynchronous find operation.
        /// The task result contains the requested <see cref="T"/>.
        /// </returns>
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// Get a list of objects where the <paramref name="predicate"/> is true.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression"/> that will be used to look for the row/document.</param>
        /// <returns>
        /// A task that represents the asynchronous where operation.
        /// The task result contains the requested <list type="T"></list>.
        /// </returns>
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// Add a row/document to the table/collection.
        /// </summary>
        /// <param name="document">The row/document that will be added to the table/collection.</param>
        /// <returns>
        /// A task that represents the asynchronous add operation.
        /// </returns>
        Task AddAsync(T document);


        /// <summary>
        /// Add a range of rows/documents to the table/collection.
        /// </summary>
        /// <param name="documents">The <list type="T"></list> that will be added to the table/collection.</param>
        /// <returns>
        /// A task that represents the asynchronous add operation.
        /// </returns>
        Task AddAsync(IEnumerable<T> documents);


        /// <summary>
        /// Remove a row/document from the table/collection.
        /// </summary>
        /// <param name="objectId">The <see cref="ObjectId"/> of the object you want to remove.</param>
        /// <returns>
        /// A task that represents the asynchronous delete operation.
        /// The task result contains the <see cref="DeleteResult"/> of the delete operation.
        /// </returns>
        Task<DeleteResult> RemoveAsync(ObjectId objectId);


        /// <summary>
        /// Remove a range of rows/documents from the table/collection.
        /// </summary>
        /// <param name="objectIds">The list of <see cref="ObjectId"/>s of the objects you want to remove.</param>
        /// <returns>
        /// A task that represents the asynchronous delete operation.
        /// The task result contains the <see cref="DeleteResult"/> of the delete operation.
        /// </returns>
        Task<DeleteResult> RemoveAsync(IEnumerable<ObjectId> objectIds);


        /// <summary>
        /// Update a value of a row/document in a table/collection.
        /// </summary>
        /// <param name="predicateSearch">The <see cref="Expression"/> that will be used to look for the row/document.</param>
        /// <param name="searchValue">The value that should match the <paramref name="predicateSearch"/> value.</param>
        /// <param name="predicateNew">The <see cref="Expression"/> that will select which variable of the row/document will be updated.</param>
        /// <param name="newValue">The value that will be set to the <paramref name="predicateNew"/> value.</param>
        Task UpdateValueAsync(Expression<Func<T, object>> predicateSearch, object searchValue, Expression<Func<T, object>> predicateNew, object newValue);


        /// <summary>
        /// Update a value of a row/document in a table/collection.
        /// </summary>
        /// <param name="objectId">The <see cref="ObjectId"/> of the object that will be updated.</param>
        /// <param name="predicateNew">The <see cref="Expression"/> that will select which variable of the row/document will be updated.</param>
        /// <param name="newValue">The value that will be set to the <paramref name="predicateNew"/> value.</param>
        Task UpdateValueAsync(ObjectId objectId, Expression<Func<T, object>> predicateNew, object newValue);


        /// <summary>
        /// Get the last documents in a collection.
        /// </summary>
        /// <param name="count">The amount of documents you want to get.</param>
        /// <returns>
        /// A task that represents the asynchronous delete operation.
        /// The task result contains a list of the requested documents.
        /// </returns>
        Task<List<T>> GetLastDocumentsAsync(int count);


        /// <summary>
        /// Get the document count of the collection.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous delete operation.
        /// The task result contains the document count.
        /// </returns>
        Task<long> DocumentCountAsync();


        /// <summary>
        /// Checks if a document exists in the collection.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression"/> that will be used to look for the row/document.</param>
        /// <returns>
        /// A task that represents the asynchronous delete operation.
        /// The task result contains whether or not the document exists.
        /// </returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
