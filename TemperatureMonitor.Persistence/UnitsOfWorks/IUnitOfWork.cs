using System;
using TemperatureMonitor.Persistence.Domain.Collections;
using TemperatureMonitor.Persistence.Repositories;

namespace TemperatureMonitor.Persistence.UnitsOfWorks
{

    /// <summary>
    /// This UnitOfWork contains all the Repositories used to query the all the tables/collections.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Contains all the queries to the <see cref="Measurement"/> table/collection.
        /// </summary>
        IMeasurementRepository Logs { get; }
    }
}
