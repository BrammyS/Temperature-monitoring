using MongoDB.Bson.Serialization.Attributes;

namespace TemperatureMonitor.Persistence.Domain.Collections
{
    public class Measurement : Document
    {
        /// <summary>
        ///     Temperature in Celsius
        /// </summary>
        [BsonElement("Celsius")]
        public double Celsius { get; set; }

        /// <summary>
        ///     Temperature in Fahrenheit
        /// </summary>
        [BsonElement("Fahrenheit")]
        public double Fahrenheit { get; set; }

        /// <summary>
        ///     Temperature in Kelvin
        /// </summary>
        [BsonElement("Kelvin")]
        public double Kelvin { get; set; }

        /// <summary>
        ///     Humidity in percentage
        /// </summary>
        [BsonElement("Humidity")]
        public double Humidity { get; set; }
    }
}