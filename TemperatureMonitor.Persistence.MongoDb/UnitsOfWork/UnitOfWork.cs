using TemperatureMonitor.Persistence.Repositories;
using TemperatureMonitor.Persistence.UnitsOfWorks;

namespace TemperatureMonitor.Persistence.MongoDb.UnitsOfWork
{

    /// <inheritdoc/>
    public class UnitOfWork : IUnitOfWork
        {

        /// <inheritdoc/>
        public IMeasurementRepository Measurements { get; }


        public UnitOfWork(IMeasurementRepository measurementRepository)
        {
            Measurements = measurementRepository;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
