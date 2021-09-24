using TemperatureMonitor.Persistence.Repositories;
using TemperatureMonitor.Persistence.UnitsOfWorks;

namespace TemperatureMonitor.Persistence.MongoDb.UnitsOfWork
{
    /// <inheritdoc />
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMeasurementRepository measurementRepository)
        {
            Measurements = measurementRepository;
        }

        /// <inheritdoc />
        public IMeasurementRepository Measurements { get; }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}