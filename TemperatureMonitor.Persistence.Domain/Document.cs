using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TemperatureMonitor.Persistence.Domain
{
    public class Document
    {
        /// <summary>
        ///     Creates a new <see cref="Document" />
        /// </summary>
        public Document()
        {
            AddedAtUtc = DateTime.UtcNow;
            BsonObjectId = ObjectId.GenerateNewId();
        }

        /// <summary>
        ///     The <see cref="ObjectId" /> of the document.
        /// </summary>
        [BsonId]
        [BsonElement("_id")]
        public ObjectId BsonObjectId { get; set; }

        /// <summary>
        ///     The <see cref="DateTime" /> of when the <see cref="Document" /> was added to the collection.
        /// </summary>
        [BsonElement("AddedAtUtc")]
        public DateTime AddedAtUtc { get; set; }
    }
}