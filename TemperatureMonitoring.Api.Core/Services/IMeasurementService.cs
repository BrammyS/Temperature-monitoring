using System.Collections.Generic;
using System.Threading.Tasks;
using TemperatureMonitor.Persistence.Domain.Collections;

namespace TemperatureMonitoring.Api.Core.Services
{
    public interface IMeasurementService
    {
        /// <summary>
        ///     Get all the measurements from today.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous get operation.
        ///     The task result contains the requested <list type="Measurement">Measurements</list>.
        /// </returns>
        Task<IEnumerable<Measurement>> GetAllMeasurementsFromToday();

        /// <summary>
        ///     Add a measurement.
        /// </summary>
        /// <param name="measurement">The <see cref="Measurement" /> that will be added to the database.</param>
        /// <returns>
        ///     A task that represents the asynchronous add operation.
        /// </returns>
        Task AddMeasurement(Measurement measurement);
    }
}