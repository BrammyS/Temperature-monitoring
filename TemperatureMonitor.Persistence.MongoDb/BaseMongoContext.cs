using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace TemperatureMonitor.Persistence.MongoDb
{

    public class BaseMongoContext
    {

        /// <summary>
        /// Creates a new <see cref="BaseMongoContext"/>.
        /// </summary>
        public BaseMongoContext()
        {
            var conventionPack = new ConventionPack
                                 {
                                     new EnumRepresentationConvention(BsonType.String)
                                 };

            ConventionRegistry.Register("EnumStringConvention", conventionPack, t => true);
        }
    }
}
