namespace TemperatureMonitor.Persistence.MongoDb.Structs
{
    public struct DbConfigModel
    {
        public string ConnectionString { get; }

        public DbConfigModel(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}