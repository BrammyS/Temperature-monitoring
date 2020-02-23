using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemperatureMonitor.Persistence.Domain.Collections;
using TemperatureMonitor.Persistence.UnitsOfWorks;

namespace TemperatureMonitoring.Api.Core.Services.Implementation
{

    public class MeasurementService : IMeasurementService
    {

        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Creates a new <see cref="MeasurementService"/>.
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> that will be used to query to the database.</param>
        public MeasurementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <inheritdoc />
        public Task<IEnumerable<Measurement>> GetAllMeasurementsFromToday()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            return _unitOfWork.Measurements.WhereAsync(x => x.AddedAtUtc > yesterday);
        }

        /// <inheritdoc />
        public Task AddMeasurement(Measurement measurement)
        {
            return _unitOfWork.Measurements.AddAsync(measurement);
        }
    }
}
