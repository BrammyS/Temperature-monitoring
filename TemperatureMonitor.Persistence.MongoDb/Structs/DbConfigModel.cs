namespace TemperatureMonitor.Persistence.MongoDb.Structs
{

    public struct DbConfigModel
    {
        public string ConnectionString { get; private set; }

        public DbConfigModel(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
