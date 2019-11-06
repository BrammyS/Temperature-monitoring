using System.IO;
using Newtonsoft.Json;
using TemperatureMonitor.Persistence.MongoDb.Structs;

namespace TemperatureMonitor.Persistence.MongoDb
{

    /// <summary>
    /// Loads the db connection string from the <see cref="ConfigFile"/>.
    /// </summary>
    public class DatabaseConfig
    {
        private const string ConfigFolder = "Configs";
        private const string ConfigFile = "DatabaseConfig.json";

        public static DbConfigModel Data;

        static DatabaseConfig()
        {

            if (!Directory.Exists(ConfigFolder)) Directory.CreateDirectory(ConfigFolder);

            if (!File.Exists(ConfigFolder + "/" + ConfigFile))
            {
                Data = new DbConfigModel();
                var json = JsonConvert.SerializeObject(Data, Formatting.Indented);
                File.WriteAllText(ConfigFolder + "/" + ConfigFile, json);
            }
            else
            {
                var json = File.ReadAllText(ConfigFolder + "/" + ConfigFile);
                Data = JsonConvert.DeserializeObject<DbConfigModel>(json);
            }
        }
    }
}

