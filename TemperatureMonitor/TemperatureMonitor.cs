using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Timers;
using Iot.Device.DHTxx;
using TemperatureMonitor.Persistence.Domain.Collections;
using TemperatureMonitor.Persistence.UnitsOfWorks;

namespace TemperatureMonitor
{
    public class TemperatureMonitor
    {
        private readonly Timer _timer;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Creates a new <see cref="TemperatureMonitor" />.
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork" /> that will be used to query to the database.</param>
        public TemperatureMonitor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _timer = new Timer
            {
                Interval = TimeSpan.FromSeconds(60).TotalMilliseconds,
                AutoReset = true,
                Enabled = true
            };
        }

        /// <summary>
        ///     Start the <see cref="Timer" />.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Starting monitoring");
            _timer.Elapsed += TimerElapsed;
        }

        /// <summary>
        ///     Activated when <see cref="_timer" /> is elapsed.
        /// </summary>
        private async void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            await Measure().ConfigureAwait(false);
        }

        /// <summary>
        ///     Starts monitoring the temperature with the <see cref="Dht22" /> sensor.
        /// </summary>
        private async Task Measure()
        {
            using var dht = new Dht22(26);
            while (true)
            {
                // Try to read the temperature.
                var temp = dht.Temperature;
                if (!dht.IsLastReadSuccessful) continue;

                // Try to read the humidity.
                var humidity = dht.Humidity.Percent;
                if (!dht.IsLastReadSuccessful) continue;

                // In case something goes horribly wrong
                if (humidity > 100) break;

                Console.WriteLine("New measurement:" +
                                  $"{temp.DegreesCelsius.ToString(CultureInfo.InvariantCulture)}c, " +
                                  $"{temp.DegreesFahrenheit.ToString(CultureInfo.InvariantCulture)}f, " +
                                  $"humidity {humidity.ToString(CultureInfo.InvariantCulture)}%");

                // Add the measurement to the database.
                try
                {
                    await _unitOfWork.Measurements.AddAsync(new Measurement
                    {
                        Celsius = temp.DegreesCelsius,
                        Fahrenheit = temp.DegreesFahrenheit,
                        Kelvin = temp.Kelvins,
                        Humidity = humidity
                    }).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to add measurement to the DB, reason {e.Message}");
                    throw;
                }

                break;
            }
        }
    }
}