using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemperatureMonitor.Persistence.Domain.Collections;
using TemperatureMonitoring.Api.Core.Services;

namespace TemperatureMonitoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        /// <summary>
        /// Creates a new <see cref="MeasurementController"/>.
        /// </summary>
        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }


        /// <summary>
        /// Get all the <see cref="Measurement"/>s from today.
        /// </summary>
        /// <example>
        /// GET: api/measurement
        /// </example>
        /// <returns>
        /// A list of <see cref="Measurement"/>s that are from today.
        /// </returns>
        [HttpGet]
        public Task<IEnumerable<Measurement>> Get()
        {
            return _measurementService.GetAllMeasurementsFromToday();
        }


        /// <summary>
        /// Get the latest <see cref="Measurement"/>.
        /// </summary>
        /// <example>
        /// GET: api/measurement/latest
        /// </example>
        /// <returns>
        /// The latest <see cref="Measurement"/>.
        /// </returns>
        [HttpGet("latest")]
        public Task<Measurement> GetLatestMeasurement()
        {
            return _measurementService.GetLatestMeasurement();
        }


        /// <summary>
        /// Get the latest <see cref="Measurement"/>.
        /// </summary>
        /// <example>
        /// POST: api/measurement
        /// </example>
        /// <returns>
        /// The added <see cref="Measurement"/>.
        /// </returns>
        [HttpPost]
        public async Task<Measurement> Post([FromBody] Measurement newMeasurement)
        {
            await _measurementService.AddMeasurement(newMeasurement).ConfigureAwait(false);
            return newMeasurement;
        }
    }
}
