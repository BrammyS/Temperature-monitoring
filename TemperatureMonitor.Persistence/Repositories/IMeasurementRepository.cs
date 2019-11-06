using TemperatureMonitor.Persistence.Domain.Collections;

namespace TemperatureMonitor.Persistence.Repositories
{

    /// <summary>
    /// This interface holds all the extra methods to query to the <see cref="Measurement"/> table/collection.
    /// </summary>
    public interface IMeasurementRepository : IRepository<Measurement>
    {
        
    }
}
