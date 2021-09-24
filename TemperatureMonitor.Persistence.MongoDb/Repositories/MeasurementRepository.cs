using TemperatureMonitor.Persistence.Domain.Collections;
using TemperatureMonitor.Persistence.Repositories;

namespace TemperatureMonitor.Persistence.MongoDb.Repositories
{
    public class MeasurementRepository : Repository<Measurement>, IMeasurementRepository
    {
        public MeasurementRepository(MongoContext context) : base(context, nameof(Measurement) + "s")
        {
        }
    }
}